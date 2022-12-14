/* Author: Reuben Tudball
 * 
 * This is an interface for BookingRepo. 
 * 
 * 
 */
namespace Hotel_Management.Models
{
    public interface IBookingRepo
    {
        IQueryable<Booking> GetBookings { get; }
        Booking this[int id] { get; }

        Booking AddBooking(Booking booking);
        Booking UpdateBooking(Booking booking);
        void DeleteBooking(Booking booking);


    }
}
