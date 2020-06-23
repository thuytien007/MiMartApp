using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

//chức năng profile này để dành tham khảo, không có trong ứng dụng mimart
namespace Application.Profiles
{
    public class Details
    {
        public class Query : IRequest<Profile>
        {
            public string Username { get; set; }
        }
        //Handler object xử lý tất cả các bussiness logic
        public class Handler : IRequestHandler<Query, Profile>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Profile> Handle(Query request, CancellationToken cancellationToken)
            {
                //handler logic
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == request.Username);

                return new Profile
                {
                    DisplayName = user.DisplayName,
                    Username = user.UserName,
                    //img có thể là giá trị null nên có dấu ?
                    //Image = user.Photos.FirstOrDefault(x => x.isMain)?.Url,
                    //Photos = user.Photos,
                };
            }
        }
    }
}