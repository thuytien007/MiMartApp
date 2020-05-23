// using System;
// using System.Collections.Generic;
// using System.Net;
// using System.Threading;
// using System.Threading.Tasks;
// using Application.Errors;
// using Domain;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Persistence;

// namespace Application.ListDetailStore
// {
//     public class ListDetailStore
//     {
//         public class Query : IRequest<List<StoreDetail>>
//         {
//             public Guid ProductId { get; set; }
//             public Guid StoreId { get; set; }
//             public string ProductName { get; set; }
//             public int Price { get; set; }
//             public int InvetoryNumber { get; set; }
//         }
//         //Handler object xử lý tất cả các bussiness logic
//         public class Handler : IRequestHandler<Query, List<StoreDetail>>
//         {
//             private readonly DataContext _context;

//             public Handler(DataContext context)
//             {
//                 _context = context;
//             }

//             public async Task<List<StoreDetail>> Handle(Query request, CancellationToken cancellationToken)
//             {
//                 //handler logic
//                 var Store = await _context.Products.ToListAsync();
//                 //đây là kiểu Eager Load
//                 // .Include(x => x.UserArticles)
//                 // .ThenInclude(x => x.AppUser)
//                 //dùng cái này thì k dùng FindAsync
//                 // .SingleOrDefaultAsync(x => x.Id == request.Id);

//                 if (Store == null)
//                 {
//                     throw new RestException(HttpStatusCode.NotFound, new { Store = "Not Found" });
//                 }
//                 return Store;
//             }
//         }
//     }
// }