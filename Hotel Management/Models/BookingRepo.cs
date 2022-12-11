using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Models
{
    public class BookingRepo : IBookingRepo
    {

        private HMContext _context;

        public BookingRepo(HMContext context)
        {
            _context = context;
        }   


        public Booking this[int id] => _context.Bookings.Where(b => b.bookingId == id).Single();

        public Booking AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking;

        }
        public Booking UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
            return booking;
        }
        public void DeleteBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }

        public IQueryable<Booking> GetBookings => _context.Bookings;

    }
}
