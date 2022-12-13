namespace Hotel_Management.Models.ViewModels
{
    public class BookingListView
    {
        public Guest guest { get; set; }
        public IEnumerable<Booking> bookings { get; set; }



    }
}
