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

        



        [HttpGet]
        public IActionResult AddBooking()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _bookingRepo.AddBooking(booking);
                return RedirectToAction("BookingHome");
            }
            return View("AddBooking");
        }

        [HttpGet]
        public IActionResult UpdateBooking(int id)
        {
            
            if ( id == 0)
            {
                return View(new Booking());
            }
            
            return View(_bookingRepo[id]);
        }

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
