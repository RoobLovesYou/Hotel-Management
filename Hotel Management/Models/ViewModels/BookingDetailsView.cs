
/* Author: Reuben Tudball
 * 
 * This is an view model class for the BookingsDetails view. 
 * 
 * 
 */
namespace Hotel_Management.Models.ViewModels
{
    public class BookingDetailsView
    {
        public Booking booking { get; set; }
        public Guest guest { get; set; }
        public Room room { get; set; }
    }
}
