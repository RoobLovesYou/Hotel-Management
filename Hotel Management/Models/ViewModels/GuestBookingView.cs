namespace Hotel_Management.Models.ViewModels
{
    public class GuestBookingView
    {
        public Booking Booking { get; set; }
        public IEnumerable<Guest> guests { get; set; }


    }
}
