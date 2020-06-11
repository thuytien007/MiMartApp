using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Stores
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

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var Store = await _context.Stores.FindAsync(request.Id);
                if (Store == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Store = "Not Found" });
                }
                //chưa xóa dc photo trên cloud
                //_photoAccessor.DeletePhoto(Partner.Logo);
                var result = _context.StoreDetails.SingleOrDefault(u => u.StoreId == Store.Id);
                if (result != null)
                {
                    throw new RestException(HttpStatusCode.Conflict, new { Store = "Cannot delete, because it already exited in other table" });
                }
                else
                {
                    _context.Stores.Remove(Store);
                }

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}