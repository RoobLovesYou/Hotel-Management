namespace Hotel_Management.Models.ViewModels
{
    public class GuestBookingView
    {
        public Guest guest { get; set; }
        public IEnumerable<Booking> bookings { get; set; }

        

    }
}
