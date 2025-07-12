using FluentValidation;
using CinemaAPI.DTO.CreateDTO;

namespace CinemaAPI.Validation.CreateValidation
{
    public class BookingCreateValidator : AbstractValidator<BookingCreate>
    {
        public BookingCreateValidator()
        {
            RuleFor(b => b.MovieID).GreaterThan(0)
                .WithMessage("Movie ID must be greater than 0.");
            RuleFor(s => s.SeatNumber)
                 .NotEmpty()
                 .WithMessage("Seat Id is required")
                 .Matches(@"^[A-Za-z]\d{1,2}$")
                 .WithMessage("Seat number must be in format like A1, b10, etc.");
            RuleFor(b => b.BookingTime)
                .NotEmpty()
                .WithMessage("Booking time is required.")
                .Must(t => t >= DateTime.Now)
                .WithMessage("Booking time must be in the present or future.");
        }

    }
}
