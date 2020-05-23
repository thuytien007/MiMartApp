using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using FluentValidation;
using MediatR;
using Persistence;
namespace Application.StatusOrders
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Description { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Description).NotEmpty();
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
                var StatusOrder = await _context.StatusOrders.FindAsync(request.Id);
                if (StatusOrder == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { StatusOrder = "Not Found" });
                }
                //câu này (??) có nghĩa user có thể update 1 thuộc tính hoặc update tất cả 
                StatusOrder.Description = request.Description ?? StatusOrder.Description;

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}