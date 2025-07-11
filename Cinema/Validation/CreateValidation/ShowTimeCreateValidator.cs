using FluentValidation;
using CinemaAPI.DTO.CreateDTO;

namespace CinemaAPI.Validation.CreateValidation
{
    public class ShowTimeCreateValidator:AbstractValidator<ShowTimeCreate>
    {
        public ShowTimeCreateValidator()
        {
            RuleFor(m => m.MovieID)
               .GreaterThan(0)
               .WithMessage("Movie ID must be greater than 0.");
            RuleFor(s => s.TheaterID)
               .GreaterThan(0)
               .WithMessage("Theater ID must be greater than 0.");
            RuleFor(b => b.StartTime)
               .NotEmpty()
               .WithMessage("Booking time is required.")
               .Must(t => t >= DateTime.Now)
               .WithMessage("Booking time must be in the present or future.");

        }
    }
}
