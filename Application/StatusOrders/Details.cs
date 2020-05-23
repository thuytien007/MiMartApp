using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;
namespace Application.StatusOrders
{
    public class Details
    {
        public class Query : IRequest<StatusOrder>
        {
            public Guid Id { get; set; }
        }
        //Handler object xử lý tất cả các bussiness logic
        public class Handler : IRequestHandler<Query, StatusOrder>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<StatusOrder> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic
                var StatusOrder = await _context.StatusOrders.FindAsync(request.Id);
                //đây là kiểu Eager Load
                // .Include(x => x.UserArticles)
                // .ThenInclude(x => x.AppUser)
                //dùng cái này thì k dùng FindAsync
                // .SingleOrDefaultAsync(x => x.Id == request.Id);

                if (StatusOrder == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { StatusOrder = "Not Found" });
                }
                return StatusOrder;
            }
        }
    }
}