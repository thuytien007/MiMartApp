using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
namespace Application.ProductGroups
{
   public class List
    {
        public class Query : IRequest<List<ProductGroup>> { }
        //Handler object xử lý tất cả các bussiness logic
        public class Handler : IRequestHandler<Query, List<ProductGroup>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<ProductGroup>> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic
                var ProductGroups = await _context.ProductGroups.ToListAsync();
                return ProductGroups;
            }
        }
    }
}