using FluentValidation;
using CinemaAPI.DTO.UserDTO;

namespace CinemaAPI.Validation.UserValidation
{
    public class LoginValidator:AbstractValidator<UserLoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Email is required .")
                .EmailAddress()
                .WithMessage("Email is not correct .");
            RuleFor(r => r.PasswordHash)
                .NotEmpty()
                .WithMessage("Password is required .");
        }
    }
}
