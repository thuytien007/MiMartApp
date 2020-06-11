using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Partners
{
    public class Details
    {
        public class Query : IRequest<Partner>
        {
            public Guid Id { get; set; }
        }
        //Handler object xử lý tất cả các bussiness logic
        public class Handler : IRequestHandler<Query, Partner>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Partner> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic
                var Partner = await _context.Partners.FindAsync(request.Id);
                //đây là kiểu Eager Load
                // .Include(x => x.UserArticles)
                // .ThenInclude(x => x.AppUser)
                //dùng cái này thì k dùng FindAsync
                // .SingleOrDefaultAsync(x => x.Id == request.Id);
                
                if (Partner == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Partner = "Not Found" });
                }
                return Partner;
            }
        }
    }
}