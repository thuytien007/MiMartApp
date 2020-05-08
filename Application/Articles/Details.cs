using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Articles
{
    public class Details
    {
        public class Query : IRequest<ArticleDto>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, ArticleDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<ArticleDto> Handle(Query request, CancellationToken cancellationToken)
            {
                 var Article = await _context.Articles.FindAsync(request.Id);
                //đây là kiểu Eager Load
                // .Include(x => x.UserArticles)
                // .ThenInclude(x => x.AppUser)
                //dùng cái này thì k dùng FindAsync
                // .SingleOrDefaultAsync(x => x.Id == request.Id);

                if (Article == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Article = "Not Found" });
                }
                var ArticleToReturn = _mapper.Map<Article, ArticleDto>(Article);
                return ArticleToReturn;
            }
        }
    }
}