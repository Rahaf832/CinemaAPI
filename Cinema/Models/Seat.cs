namespace CinemaAPI.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; }
        public int TheaterId { get; set; } // Foriegn key for Theater
        public Theater Theater { get; set; } 
        
        public ICollection<ShowTimeSeat> ShowTimeSeats { get; set; }

    }
}
