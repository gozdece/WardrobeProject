using Core.Dtos.UserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validations
{
    internal class UserLoginDtoValidator: AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} must be email address");

            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .MaximumLength(20).WithMessage("{PropertyName} must be lower than 20 character")
                .MinimumLength(8).WithMessage("{PropertyName} must be greater than 8 character");
        }
    }
}
