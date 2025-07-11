namespace CinemaAPI.Models
{
    public class ShowTime
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Price { get; set; }

        public int MovieId { get; set; }//foriegn key for movie
        public Movie Movie { get; set; }

        public int TheaterId { get; set; }//foriegn key for Theater
        public Theater Theater { get; set; }

        public ICollection<ShowTimeSeat> ShowTimeSeats { get; set; }
    }
}
