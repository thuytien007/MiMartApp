// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using AutoMapper;
// using Domain;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Persistence;
// namespace Application.User
// {
//     public class List
//     {
//         public class Query : IRequest<List<User>>
//         {
//             public string DisplayName { get; set; }
//             public string Token { get; set; }
//             public string UserName { get; set; }
//             public string Avatar { get; set; }
//         }
//         //Handle object xử lý tất cả các bussiness logic
//         public class Handler : IRequestHandler<Query, List<User>>
//         {
//             private readonly DataContext _context;
//             //private readonly IMapper _mapper;

//             public Handler(DataContext context)
//             {
//                 //_mapper = mapper;
//                 _context = context;
//             }

//             public async Task<List<User>> Handle(Query request, CancellationToken cancellationToken)
//             {
//                 var Users = await _context..ToListAsync();
//                 return Users;
//             }
//         }
//     }
// }