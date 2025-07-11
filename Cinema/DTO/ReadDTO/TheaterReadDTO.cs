namespace CinemaAPI.DTO.ReadDTO
{
    public class TheaterReadDTO
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool? IsVIP { get; set; }
        public bool? Is3D { get; set; }
    }
}
