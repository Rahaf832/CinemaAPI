using FluentValidation;
using CinemaAPI.DTO.UpdateDTO;

namespace CinemaAPI.Validation.UpdateValidation
{
    public class SeatUpdateValidator:AbstractValidator<SeatUpdate>
    {
        public SeatUpdateValidator()
        {
            RuleFor(s => s.SeatNumber)
                 .NotEmpty()
                 .WithMessage("Seat Id is required")
                 .Matches(@"^[A-Za-z]\d{1,2}$")
                 .WithMessage("Seat number must be in format like A1, b10, etc.");
        }
    }
}
