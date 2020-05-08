using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Articles
{
    public class Unattend
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                var Article = await _context.Articles.FindAsync(request.Id);

                if (Article == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new { Article = "Could not find Article" });

                var user = await _context.Users.SingleOrDefaultAsync(x
                    => x.UserName == _userAccessor.GetCurrentUsername());

                var attendance = await _context.UserArticles.SingleOrDefaultAsync(x =>
                    x.ArticleId == Article.Id && x.AppUserId == user.Id);

                if (attendance == null)
                    return Unit.Value;
                if (attendance.IsHost)
                {
                    throw new RestException(HttpStatusCode.BadRequest,
                        new { Attendance = "You can not remove yourself as host" });
                }

                _context.UserArticles.Remove(attendance);

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}