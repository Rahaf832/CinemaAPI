using FluentValidation;
using CinemaAPI.DTO.CreateDTO;

namespace CinemaAPI.Validation.CreateValidation
{
    public class MovieCreateValidator : AbstractValidator<MovieCreateDTO>
    {
        public MovieCreateValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage("Title is required");
            RuleFor(m => m.Description)
                .NotEmpty()
                .MaximumLength(500)
                .WithMessage("Description is required.");
            RuleFor(m => m.Genre)
                .Must(g => Enum.TryParse<Models.Genre>(g, true, out _))
                .WithMessage("Invalid genre type.");
        }
    }
}
