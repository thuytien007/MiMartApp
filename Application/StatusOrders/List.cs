using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.StatusOrders
{
    public class List
    {
        public class Query : IRequest<List<StatusOrder>> { }
        //Handler object xử lý tất cả các bussiness logic
        public class Handler : IRequestHandler<Query, List<StatusOrder>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<StatusOrder>> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic
                var StatusOrders = await _context.StatusOrders.ToListAsync();
                return StatusOrders;
            }
        }
    }
}