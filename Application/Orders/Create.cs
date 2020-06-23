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

namespace Application.Orders
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public DateTime DayOfOrder { get; set; }
            public int Total { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DayOfOrder).NotEmpty();
                RuleFor(x => x.Total).NotEmpty();
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
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());
                var order = new Order
                {
                    Id = request.Id,
                    DateOfOrder = request.DayOfOrder,
                    Total = request.Total,
                    AppUser = user
                };
                _context.Orders.Add(order);

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}