using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using MediatR;
using Persistence;
namespace Application.Partners
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;

            public Handler(DataContext context, IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var Partner = await _context.Partners.FindAsync(request.Id);
                if (Partner == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Article = "Not Found" });
                }
                //chưa xóa dc photo trên cloud
                //_photoAccessor.DeletePhoto(Partner.Logo);
                var result = _context.Stores.FindAsync(Partner.Id);
                if(result != null)
                {
                     throw new RestException(HttpStatusCode.Conflict, new { Article = "Cannot delete, because it already exited in other table" });
                }
                _context.Partners.Remove(Partner); 

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}