using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using Application.Errors;
using System.Net;

namespace Application.Photos
{
    public class SetMain
    {
        public class Command : IRequest
        {
            //ta cần biết user sẽ chọn bức ảnh nào làm bức main nên sẽ có Id b.ảnh đó
            public string Id { get; set; }
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
                //handler logic
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName ==
                _userAccessor.GetCurrentUsername());

                //var photo = user.Photos.FirstOrDefault(x => x.Id == request.Id);

                //if(photo == null)
                    //throw new RestException(HttpStatusCode.NotFound, new { Photo = "Not found"});
                
                //tìm b.ảnh đang là main hiện tại gán lại là false
                //var currentMain = user.Photos.FirstOrDefault(x => x.isMain);
                //currentMain.isMain = false;
                //bức đã chọn gán main lại là true
               //photo.isMain = true;
                
                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}