namespace CinemaAPI.DTO.ReadDTO
{
    public class RoleDTORead
    {
        public string Name { get; set; }

        public ICollection<UserReadDTO> GetUsers { get; set; }
    }
}
