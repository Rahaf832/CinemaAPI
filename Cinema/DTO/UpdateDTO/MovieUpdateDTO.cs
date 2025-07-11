namespace CinemaAPI.DTO.UpdateDTO
{
    public class MovieUpdateDTO
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Language { get; set; }
        public string AgeRestriction { get; set; }
        public string? PosterUrl { get; set; }
    }
}
