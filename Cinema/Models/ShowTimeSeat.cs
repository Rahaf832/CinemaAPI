namespace CinemaAPI.Models
{
    public class ShowTimeSeat
    {
        public int Id { get; set; }

        //related with booking to know who is booking
        public int? BookingId { get; set; }
        public Booking Booking { get; set; }

        public bool IsReserved { get; set; }

        //related with Showtime to know The Movie and its ShowTime
        public int ShowTimeId { get; set; }
        public ShowTime ShowTime { get; set; }

        //related with Seat to know number of seat
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}
