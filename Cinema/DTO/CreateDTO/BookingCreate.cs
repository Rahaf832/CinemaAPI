namespace CinemaAPI.DTO.CreateDTO
{
    public class BookingCreate
    {
        public int MovieID { get; set; }
        public int SeatID { get; set; }//المقعد المحجوز بالعرض 
        public DateTime BookingTime { get; set; }
    }
}
