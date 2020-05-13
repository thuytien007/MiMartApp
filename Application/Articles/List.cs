using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Articles
{
    public class List
    {
        public class Query : IRequest<List<Article>> { }
        //Handle object xử lý tất cả các bussiness logic
        public class Handler : IRequestHandler<Query, List<Article>>
        {
            private readonly DataContext _context;
            //private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                //_mapper = mapper;
                _context = context;
            }

            public async Task<List<Article>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Articles = await _context.Articles.ToListAsync();
                return Articles;
            }
        }
    }
}