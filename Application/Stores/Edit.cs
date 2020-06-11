using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Stores
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Address { get; set; }
            public string District { get; set; }
            public string Coordinates { get; set; }
            public string PartnerId { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Address).NotEmpty();
                RuleFor(x => x.District).NotEmpty();
                RuleFor(x => x.Coordinates).NotEmpty();
                RuleFor(x => x.PartnerId).NotEmpty();
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
                var Store = await _context.Stores.FindAsync(request.Id);
                var partnerId = await _context.Partners.SingleOrDefaultAsync(n => n.PartnerName == request.PartnerId);
                if (Store == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Store = "Not Found" });
                }

                Store.Address = request.Address ?? Store.Address;
                Store.District = request.District ?? Store.District;
                Store.Coordinates = request.Coordinates ?? Store.Coordinates;
                if (request.PartnerId == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Store = "Cannot Find Partner for Store" });
                }
                else
                {
                    Store.Partner = partnerId;
                    var success = await _context.SaveChangesAsync() > 0;
                    if (success)
                        return Unit.Value;
                    throw new Exception("Problem saving changes");
                }
            }
        }
    }
}