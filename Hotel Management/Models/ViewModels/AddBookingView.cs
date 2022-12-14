/* Author: Reuben Tudball
 * 
 * This is an view model class for AddBookings view. 
 * 
 * 
 */

namespace Hotel_Management.Models.ViewModels
{
    public class AddBookingView
    {
        public Booking Booking { get; set; }
        public IEnumerable<Guest> guests { get; set; }

        public IEnumerable<Room> rooms { get; set; }
    }
}
