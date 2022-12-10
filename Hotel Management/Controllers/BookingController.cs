using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    public class BookingController : Controller
    {
        private IBookingRepo _bookingRepo;

        public BookingController(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }


        //temp
        [HttpGet]
        public IEnumerable<Booking> BookingHome() => _bookingRepo.GetBookings;




    }
}
