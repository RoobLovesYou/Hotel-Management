/* Author: Reuben Tudball
 * 
 * This is an  model class for Bookings. 
 * 
 * 
 */
namespace Hotel_Management.Models
{
    public class Booking
    {
        public int bookingId { get; set; }
        public DateTime BookingDateFrom { get; set; }
        public DateTime BookingDateTo { get; set; }
        public decimal Deposit { get; set; }
        public bool Status { get; set; }
        public int guestId { get; set; }
        public int roomId { get; set; }

    }
}
