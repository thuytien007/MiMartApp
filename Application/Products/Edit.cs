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
namespace Application.Products
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string ProductName { get; set; }
            public string CalculationUnit { get; set; }
            public string ProductImage { get; set; }
            public string Description { get; set; }
            public string Instructions { get; set; }
            public DateTime? ManufacturingDate { get; set; }
            public DateTime? ExpiryDate { get; set; }
            public string ProductGroup { get; set; }
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
                var Product = await _context.Products.FindAsync(request.Id);

                var productGroupId = await _context.ProductGroups.SingleOrDefaultAsync(n => n.GroupName == request.ProductGroup);

                if (Product == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Product = "Not Found" });
                }
                var photoUploadResult = _photoAccessor.AddPhoto(request.File);
                //câu này (??) có nghĩa user có thể update 1 thuộc tính hoặc update tất cả 
                Product.ProductName = request.ProductName ?? Product.ProductName;
                Product.CalculationUnit = request.CalculationUnit ?? Product.CalculationUnit;
                Product.Description = request.Description ?? Product.Description;
                Product.Instructions = request.Instructions ?? Product.Instructions;
                Product.ManufacturingDate = request.ManufacturingDate ?? Product.ManufacturingDate;
                Product.ExpiryDate = request.ExpiryDate ?? Product.ExpiryDate;
                 //set nhóm sản phẩm
                if (request.ProductGroup == null)
                {
                    Product.ProductGroup = Product.ProductGroup;
                }
                else
                {
                    Product.ProductGroup = productGroupId;
                }
                
                if (request.ProductImage == null)
                {
                    Product.ProductImage = Product.ProductImage;
                }
                else
                {
                    Product.ProductImage = photoUploadResult.Url;
                }
               
                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}