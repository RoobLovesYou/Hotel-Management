using Hotel_Management.Models;
using Hotel_Management.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    public class BookingController : Controller
    {
        private IBookingRepo _bookingRepo;
        private IGuestRepo _guestRepo;

        public BookingController(IBookingRepo bookingRepo, IGuestRepo guestRep)
        {
            _bookingRepo = bookingRepo;
            _guestRepo = guestRep;
        }

        [HttpGet]
        public IActionResult BookingHome()
        {
            return View(_bookingRepo.GetBookings);
        }


        
        [HttpGet]
        public IActionResult AddBooking()
        {
            GuestBooking gb = new GuestBooking();

            gb.Booking = new Booking();
            gb.guests = _guestRepo.GetGuests;
            

            return View(gb);
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
            if (ModelState.IsValid)
            {
                _bookingRepo.UpdateBooking(booking);
                return RedirectToAction("BookingHome");
            }
            return View("UpdateBooking");
        }

        [HttpPost, ActionName("DeleteBooking")]
        public IActionResult DeleteConfirm(int id)
        {
            var booking = _bookingRepo[id];
            _bookingRepo.DeleteBooking(booking);
            return RedirectToAction("BookingHome");
        }

    }
}
