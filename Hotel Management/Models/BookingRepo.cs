namespace Hotel_Management.Models
{
    public class BookingRepo : IBookingRepo
    {

        public Booking this[int id] => new Booking { };

        public Booking AddBooking(Booking booking)
        {
            return null;

        }
        public Booking UpdateBooking(Booking booking)
        {
            return null;
        }
        public void DeleteBooking(Booking booking)
        {

        }

       // public IQueryable<Booking> GetBookings => TODO

    }
}
