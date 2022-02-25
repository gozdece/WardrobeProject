using Core.Dtos.ProductDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validations
{
    public class PostProductDtoValidator :AbstractValidator<PostProductDto>
    {
        public PostProductDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} can be max 100 character");

            RuleFor(x => x.Description).NotNull().WithMessage("{PropertyName} is required")
               .NotEmpty().WithMessage("{PropertyName} is required")
               .MaximumLength(500).WithMessage("{PropertyName} can be max 500 character");

            RuleFor(x => x.CategoryId).NotNull().WithMessage("{PropertyName} is required")
               .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.ColorId).NotNull().WithMessage("{PropertyName} is required")
               .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.BrandId).NotNull().WithMessage("{PropertyName} is required")
               .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.UsageStatusId).NotNull().WithMessage("{PropertyName} is required")
               .NotEmpty().WithMessage("{PropertyName} is required");

            //RuleFor(x => x.Photo).SetValidator(new FileValidator(400));

            RuleFor(x => x.Price).InclusiveBetween(1, decimal.MaxValue).WithMessage("{PropertyName} must be greater than 0");
            //RuleFor(x => x.IsOfferable).InclusiveBetween(true, false).WithMessage("{PropertyName} must be boolean");
        }
    }
}
