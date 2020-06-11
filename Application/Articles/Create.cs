using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
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
            //public Guid AppUser { get; set; }
            public DateTime Date { get; set; }
            public string Image { get; set; }
            public IFormFile File { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.Date).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IPhotoAccessor _photoAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor, IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                
                var photoUploadResult = _photoAccessor.AddPhoto(request.File);
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());
                var Article = new Article
                {
                    Id = request.Id,
                    Title = request.Title,
                    Description = request.Description,
                    Date = request.Date,
                    Image = photoUploadResult.Url,
                    AppUser = user,
                };
                _context.Articles.Add(Article);

                // var attendee = new UserArticle
                // {
                //     AppUser = user,
                //     Article = Article,
                //     IsHost = true,
                //     DateJoined = DateTime.Now
                // };
                // _context.UserArticles.Add(attendee);

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}