using Google.Apis.Calendar.v3.Data;

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
