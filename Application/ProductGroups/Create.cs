using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
namespace Application.ProductGroups
{
    public class Create
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
                var productGroup = new ProductGroup
                {
                    Id = request.Id,
                    GroupName = request.GroupName,
                };
                _context.ProductGroups.Add(productGroup);

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}