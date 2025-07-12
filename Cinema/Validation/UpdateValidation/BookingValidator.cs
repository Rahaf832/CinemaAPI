using FluentValidation;
using CinemaAPI.DTO.UpdateDTO;

namespace CinemaAPI.Validation.UpdateValidation
{
    public class BookingValidator:AbstractValidator<BookingUpdate>
    {
        public BookingValidator()
        {
            RuleFor(s => s.SeatNumber)
                 .NotEmpty()
                 .WithMessage("Seat Id is required")
                 .Matches(@"^[A-Za-z]\d{1,2}$")
                 .WithMessage("Seat number must be in format like A1, b10, etc.");
            RuleFor(s => s.BookingTime)
                .Must(s => s >= DateTime.Now)
                .WithMessage("Booking time must be in the present or future.");

        }
    }
}
