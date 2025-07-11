using FluentValidation;
using CinemaAPI.DTO.CreateDTO;

namespace CinemaAPI.Validation.CreateValidation
{
    public class SeatCreateValidator:AbstractValidator<SeatCreate>
    {
        public SeatCreateValidator()
        {
            RuleFor(s => s.SeatNumber)
                .NotEmpty()
                .WithMessage("Seat Id is required")
                .Matches(@"^[A-Za-z]\d{1,2}$")
                .WithMessage("Seat number must be in format like A1, b10, etc.");

            RuleFor(s => s.TheaterID)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Theater ID must be greater than 0.");
        }


    }
}
