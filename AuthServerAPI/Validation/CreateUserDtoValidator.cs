using AuthServer.Core.Dtos;
using FluentValidation;

namespace AuthServer.API.Validation
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(prop => prop.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(prop => prop.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is wrong");
            RuleFor(prop => prop.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
