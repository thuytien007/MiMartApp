using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;
namespace Application.ProductGroups
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
                var ProductGroup = await _context.ProductGroups.FindAsync(request.Id);
                if (ProductGroup == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new{ProductGroup = "Not Found"});
                }

                // var result = _context.Products.FindAsync(request.Id);
                // if(result != null)
                // {
                //      throw new RestException(HttpStatusCode.Conflict, new { ProductGroup = "Cannot delete, because it already exited in other table" });
                // }

                _context.ProductGroups.Remove(ProductGroup);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}