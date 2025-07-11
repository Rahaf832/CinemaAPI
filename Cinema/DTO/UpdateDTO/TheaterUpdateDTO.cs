namespace CinemaAPI.DTO.UpdateDTO
{
    public class TheaterUpdateDTO
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool? IsVIP { get; set; }
        public bool? Is3D { get; set; }
    }
}
