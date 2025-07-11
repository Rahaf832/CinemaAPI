namespace CinemaAPI.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //One Role has many Users
        public ICollection<User> Users { get; set; }
    }
}
