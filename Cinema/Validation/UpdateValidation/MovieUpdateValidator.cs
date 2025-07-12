using FluentValidation;
using CinemaAPI.DTO.UpdateDTO;

namespace CinemaAPI.Validation.UpdateValidation
{
    public class MovieUpdateValidator:AbstractValidator<MovieUpdateDTO>
    {
        public MovieUpdateValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage("Movie title is required .");
            RuleFor(m => m.Description)
                .NotEmpty()
                .WithMessage("Description is required .")
                .MaximumLength(500)
                .WithMessage("Too much ! The maximun length is 500 .");
            RuleFor(m => m.Genre)
                .NotEmpty()
                .Must(m => Enum.TryParse<Models.Genre>(m, true, out _))
                .WithMessage("Invalid genre type .");
            RuleFor(m => m.DurationInMinutes)
                .GreaterThan(0)
                .WithMessage("Duration must be greater than 0 .");
            RuleFor(m => m.ReleaseDate)
                .Must(m => m <= DateTime.UtcNow)
                .WithMessage("Release date must be before presesnt .");
            RuleFor(m => m.AgeRestriction)
                .Matches(@"^+\d{1,2}$")
                .WithMessage("Age restriction must write like +18 .");

        }

    }
}
