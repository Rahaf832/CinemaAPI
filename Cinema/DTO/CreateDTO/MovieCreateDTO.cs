namespace CinemaAPI.DTO.CreateDTO
{
    public class MovieCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int DurationInMinutes { get; set; }
        public string Language { get; set; }
        public string AgeRestriction { get; set; }
    }
}
