using FluentValidation;
using CinemaAPI.DTO.UpdateDTO;

namespace CinemaAPI.Validation.UpdateValidation
{
    public class ShowTimeUpdateValidaator:AbstractValidator<ShowTimeUpdate>
    {
        public ShowTimeUpdateValidaator()
        {
            RuleFor(s=>s.StartTime)
                 .Must(s => s > DateTime.Now)
                .WithMessage("Start time must be in the future.");
            RuleFor(s => s.EndTime)
                .GreaterThan(s => s.StartTime)
                .WithMessage("End time must be greater than start time .");
            RuleFor(s => s.Price)
                .GreaterThan(0)
                .When(s => s.Price.HasValue);
            
        }
    }
}
