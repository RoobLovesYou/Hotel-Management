using Hotel_Management.Models;
using Hotel_Management.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    public class BookingController : Controller
    {
        private IBookingRepo _bookingRepo;
        private IGuestRepo _guestRepo;
        private IRoomRepo _roomRepo;

        public BookingController(IBookingRepo bookingRepo, IGuestRepo guestRep, IRoomRepo roomRepo)
        {
            _bookingRepo = bookingRepo;
            _guestRepo = guestRep;
            _roomRepo = roomRepo;
        }

        [HttpGet]
        public IActionResult BookingHome()
        {
           GuestBookingView blv = new GuestBookingView();
            blv.bookings = _bookingRepo.GetBookings;

           

            return View(_bookingRepo.GetBookings);
        }


        
        [HttpGet]
        public IActionResult AddBooking()
        {
            AddBookingView abv = new AddBookingView();
            abv.guests = _guestRepo.GetGuests;
            return View(abv);
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
