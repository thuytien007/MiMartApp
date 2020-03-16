using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }
        //Handle object xử lý tất cả các bussiness logic
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await _context.Activities.ToListAsync();
                //có nghĩa khi get list or get id sẽ trả về dl của những table có liên quan đến table activity
                    //.Include(x =>x.UserActivities)
                    //.ThenInclude(x =>x.AppUser)
                   // .ToListAsync();
                return activities;
            }
        }
    }
}