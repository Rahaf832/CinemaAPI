using FluentValidation;
using CinemaAPI.DTO.CreateDTO;

namespace CinemaAPI.Validation.CreateValidation
{
    public class TheaterCreateValidator:AbstractValidator<TheaterCreateDTO>
    {
        public TheaterCreateValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .WithMessage("Theater name is required.")
                .MinimumLength(2)
                .MaximumLength(50)
                .WithMessage("Theater name must be between 2 and 50 characters.");
            RuleFor(c => c.Capacity)
                .GreaterThan(0)
                .WithMessage("Theater capacity must be greater than 0.");
        }
    }
}
