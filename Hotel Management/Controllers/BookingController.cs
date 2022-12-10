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



        [HttpGet]
       // public IEnumerable<Booking> BookingHome() => _bookingRepo.GetBookings;
        public IActionResult BookingHome()
        {
            return View(_bookingRepo.GetBookings);
        }

        //     [HttpDelete]
        //     public void Delete(int id) => _bookingRepo.DeleteBooking(id);
       
        /*
        [HttpPost]
        public IActionResult UpdateBooking(Booking booking)
        {
            // _bookingRepo.UpdateBooking(booking);
            if (ModelState.IsValid)
            {
             //   _bookingRepo.UpdateBooking(booking);
                return RedirectToAction("UpdateBooking");
            }
            return View("BookingHome");
        }*/

    }
}
