namespace CinemaAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int MovieID { get; set; }
        public int SeatID { get; set; }//المقعد المحجوز بالعرض 
        public string SeatNumber { get; set; }
        public DateTime BookingTime { get; set; }
        public bool IsPaid { get; set; }
        public int UserId { get; set; } //Foreign Key for User
        public User User { get; set; }

        public ShowTimeSeat ShowTimeSeat { get; set; }
    }
}
