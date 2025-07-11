namespace CinemaAPI.DTO.UpdateDTO
{
    public class ShowTimeUpdate
    {
        public int MovieID { get; set; }
        public int TheaterID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double? Price { get; set; }
    }
}
