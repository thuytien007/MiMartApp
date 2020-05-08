using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Articles
{
    public class Edit
    {
         public class Command : IRequest{
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Author{ get; set; }
            public DateTime? Date { get; set; }
            public string Image { get; set; }
         }
         public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.Author).NotEmpty();
                RuleFor(x => x.Date).NotEmpty();
                RuleFor(x => x.Image).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var Article = await _context.Articles.FindAsync(request.Id);
                if (Article == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new{Article = "Not Found"});
                }
                //câu này (??) có nghĩa user có thể update 1 thuộc tính hoặc update tất cả 
                Article.Title = request.Title ?? Article.Title;
                Article.Description = request.Description ?? Article.Description;
                Article.Author= request.Author?? Article.Author;
                Article.Date = request.Date ?? Article.Date;
                Article.Image = request.Image ?? Article.Image;
                var success = await _context.SaveChangesAsync() > 0;
                
                if (success) 
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}