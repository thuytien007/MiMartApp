using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Partners
{
    public class List
    {
        public class Query : IRequest<List<Partner>> { }
        //Handler object xử lý tất cả các bussiness logic
        public class Handler : IRequestHandler<Query, List<Partner>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Partner>> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic
                var Partners = await _context.Partners.ToListAsync();
                return Partners;
            }
        }
    }
}