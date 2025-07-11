namespace CinemaAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
         
        public List<Booking> Bookings { get; set; } = new List<Booking>(); //يمكن للمستخدم القيام بأكثر من حجر 

        //every user has one role
        public int RoleId { get; set; }//Foriegn key for role
        public Role Role { get; set; }

    }
}
