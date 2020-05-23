using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;
namespace Application.StatusOrders
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
                var StatusOrder = await _context.StatusOrders.FindAsync(request.Id);
                if (StatusOrder == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new{StatusOrder = "Not Found"});
                }
                _context.StatusOrders.Remove(StatusOrder);
                
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}