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
using Persistence;

namespace Application.Partners
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string PartnerName { get; set; }
            public string Logo { get; set; }
            public IFormFile File { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.PartnerName).NotEmpty();
                RuleFor(x => x.Logo).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;

            public Handler(DataContext context, IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var Partner = await _context.Partners.FindAsync(request.Id);
                if (Partner == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Article = "Not Found" });
                }
                var photoUploadResult = _photoAccessor.AddPhoto(request.File);
                //câu này (??) có nghĩa user có thể update 1 thuộc tính hoặc update tất cả 
                Partner.PartnerName = request.PartnerName ?? Partner.PartnerName;
                if (photoUploadResult == null)
                {
                    Partner.Logo = Partner.Logo;
                }
                else
                {
                    Partner.Logo = photoUploadResult.Url;
                }

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}