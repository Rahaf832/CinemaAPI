using Microsoft.EntityFrameworkCore;
using CinemaAPI.Models;

namespace CinemaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base (options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ShowTime> Shows { get; set; }
        public DbSet<ShowTimeSeat> ShowTimeSeats { get; set; }    
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One User With many bookings
            modelBuilder.Entity<User>()
                .HasMany(u => u.Bookings)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            //One Role has many Users
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(r => r.Role)
                .HasForeignKey(r => r.RoleId);

            //One Movie with many ShowTimes
            modelBuilder.Entity<Movie>()
                .HasMany(sh=>sh.ShowTimes)
                .WithOne(sh=>sh.Movie)
                .HasForeignKey(sh=>sh.MovieId);

            //One Theater with many showTimes
            modelBuilder.Entity<Theater>()
                .HasMany(th => th.ShowTimes)
                .WithOne(th => th.Theater)
                .HasForeignKey(th => th.TheaterId);

            //One Theater with many Seats
            modelBuilder.Entity<Theater>()
                .HasMany(t => t.Seats)
                .WithOne(t => t.Theater)
                .HasForeignKey(t => t.TheaterId);

            //Booking with ShowTimeSeats
            modelBuilder.Entity<ShowTimeSeat>()
                .HasOne(ss => ss.Booking)
                .WithOne(b => b.ShowTimeSeat)
                .HasForeignKey<ShowTimeSeat>(ss => ss.BookingId)
                .IsRequired(false);
            //Many-To-Mony
            modelBuilder.Entity<ShowTimeSeat>()
                .HasKey(ss => new { ss.ShowTimeId, ss.SeatId });
            modelBuilder.Entity<ShowTimeSeat>()
                .HasOne(ss => ss.ShowTime)
                .WithMany(s => s.ShowTimeSeats)
                .HasForeignKey(s => s.ShowTimeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ShowTimeSeat>()
                .HasOne(ss => ss.Seat)
                .WithMany(s => s.ShowTimeSeats)
                .HasForeignKey(S => S.SeatId)
                .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
