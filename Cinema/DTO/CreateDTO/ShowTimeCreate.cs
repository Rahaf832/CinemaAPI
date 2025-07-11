namespace CinemaAPI.DTO.CreateDTO
{
    public class ShowTimeCreate
    {
        public int MovieID { get; set; }
        public int TheaterID { get; set; }
        public DateTime StartTime { get; set; }
    }
}
