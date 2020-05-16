using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;
namespace Application.Products
{
    public class Details
    {
        public class Query : IRequest<Product>
        {
            public Guid Id { get; set; }
        }
        //Handler object xử lý tất cả các bussiness logic
        public class Handler : IRequestHandler<Query, Product>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Product> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic
                var Product = await _context.Products.FindAsync(request.Id);
                //đây là kiểu Eager Load
                // .Include(x => x.UserArticles)
                // .ThenInclude(x => x.AppUser)
                //dùng cái này thì k dùng FindAsync
                // .SingleOrDefaultAsync(x => x.Id == request.Id);

                if (Product == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Product = "Not Found" });
                }
                return Product;
            }
        }
    }
}