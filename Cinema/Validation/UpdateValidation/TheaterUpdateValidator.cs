using FluentValidation;
using CinemaAPI.DTO.UpdateDTO;

namespace CinemaAPI.Validation.UpdateValidation
{
    public class TheaterUpdateValidator:AbstractValidator<TheaterUpdateDTO>
    {
        public TheaterUpdateValidator()
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
