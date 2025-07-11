namespace CinemaAPI.Models
{
    public class Theater
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool IsVIP { get; set; }
        public bool Is3D { get; set; }

        //The Theater has many Shows 
        public List<ShowTime> ShowTimes { get; set; }=new List<ShowTime>();
        //The Teater has many seats
        public List<Seat> Seats { get; set; }=new List<Seat>();
    }
}
