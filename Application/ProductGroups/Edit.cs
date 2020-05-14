using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
namespace Application.ProductGroups
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string GroupName { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.GroupName).NotEmpty();
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
                var ProductGroup = await _context.ProductGroups.FindAsync(request.Id);
                if (ProductGroup == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { ProductGroup = "Not Found" });
                }
                //câu này (??) có nghĩa user có thể update 1 thuộc tính hoặc update tất cả 
                ProductGroup.GroupName = request.GroupName ?? ProductGroup.GroupName;

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}