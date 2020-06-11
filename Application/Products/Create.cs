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
namespace Application.Products
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string ProductName { get; set; }
            public string CalculationUnit { get; set; }
            public string ProductImage { get; set; }
            public string Description { get; set; }
            public string Instructions { get; set; }
            public DateTime ManufacturingDate { get; set; }
            public DateTime ExpiryDate { get; set; }
            public string ProductGroup {get; set; }
            public IFormFile File { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductName).NotEmpty();
                RuleFor(x => x.CalculationUnit).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.Instructions).NotEmpty();
                RuleFor(x => x.ManufacturingDate).NotEmpty();
                RuleFor(x => x.ExpiryDate).NotEmpty();
                RuleFor(x => x.ProductGroup).NotEmpty();
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
                var photoUploadResult = _photoAccessor.AddPhoto(request.File);
                var productGroupId = await _context.ProductGroups.SingleOrDefaultAsync(n =>n.GroupName==request.ProductGroup);
                var product = new Product
                {
                    Id = request.Id,
                    ProductName = request.ProductName,
                    Description = request.Description,
                    Instructions = request.Instructions,
                    CalculationUnit = request.CalculationUnit,
                    ManufacturingDate = request.ManufacturingDate,
                    ExpiryDate = request.ExpiryDate,
                    ProductImage = photoUploadResult.Url,
                    ProductGroup = productGroupId
                };
                _context.Products.Add(product);

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}