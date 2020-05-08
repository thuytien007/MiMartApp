using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Articles
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Author{ get; set; }
            public DateTime Date { get; set; }
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
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var Article = new Article
                {
                    Id = request.Id,
                    Title = request.Title,
                    Description = request.Description,
                    Author= request.Author,
                    Date = request.Date,
                    Image = request.Image,
                };
                _context.Articles.Add(Article);
                
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());
                var attendee = new UserArticle
                {
                    AppUser = user,
                    Article = Article,
                    IsHost = true,
                    DateJoined = DateTime.Now
                };
                _context.UserArticles.Add(attendee);

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}