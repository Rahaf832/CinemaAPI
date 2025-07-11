namespace CinemaAPI.DTO.ReadDTO
{
    public class BookingRead
    {
        public int MovieID { get; set; }
        public int SeatID { get; set; }//المقعد المحجوز بالعرض 
        public DateTime BookingTime { get; set; }
        public bool IsPaid { get; set; }
    }
}
