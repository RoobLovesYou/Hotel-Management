using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Models
{
    public class HMContext : DbContext
    {

        public HMContext()
        {
        }

        public HMContext(DbContextOptions<HMContext> options) : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }

        public virtual DbSet<Guest> Guests { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }
    }
}
