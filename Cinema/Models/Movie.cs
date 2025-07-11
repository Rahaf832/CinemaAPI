namespace CinemaAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Language { get; set; }
        public string AgeRestriction { get; set; }
        public string? PosterUrl { get; set; }


        //الفلم الواحد يملك اكثر من وقت عرض اي يعرض عة مرات
        public List<ShowTime> ShowTimes { get; set; }=new List<ShowTime>();
    }
}
