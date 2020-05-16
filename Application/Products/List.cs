using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
namespace Application.Products
{
    public class List
    {
        public class Query : IRequest<List<Product>> { }
        //Handler object xử lý tất cả các bussiness logic
        public class Handler : IRequestHandler<Query, List<Product>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Product>> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic
                var Products = await _context.Products.ToListAsync();
                return Products;
            }
        }
    }
}