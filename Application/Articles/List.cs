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
        public class Query : IRequest<List<ArticleDto>> { }
        //Handle object xử lý tất cả các bussiness logic
        public class Handler : IRequestHandler<Query, List<ArticleDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<ArticleDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Articles = await _context.Articles.ToListAsync();
                return _mapper.Map<List<Article>, List<ArticleDto>>(Articles);
            }
        }
    }
}