namespace Hotel_Management.Models.ViewModels
{
    public class AddBookingView
    {
        public Booking Booking { get; set; }
        public IEnumerable<Guest> guests { get; set; }

        public IEnumerable<Room> rooms { get; set; }
    }
}
