using FluentValidation;
using CinemaAPI.DTO.UserDTO;

namespace CinemaAPI.Validation.UserValidation
{
    public class RegisterValidator:AbstractValidator<UserRegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Name is required .");
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Email is required .")
                .EmailAddress()
                .WithMessage("Email is not correct .");
            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Password is required .");
             
        }
    }
}
