using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingAPIController : Controller
    {
        private IBookingRepo _bookingRepo;

        public BookingAPIController(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        [HttpGet]
        public IEnumerable<Booking> Get() => _bookingRepo.GetBookings;

        [HttpGet("{id}")]
        public ActionResult<Booking> Get(int id)
        {
            if(id == 0)
                return BadRequest("Invalid ID");
            return Ok(_bookingRepo[id]);
        }

        [HttpPost]
        public Booking Post([FromBody] Booking bookPost) => _bookingRepo.AddBooking(new Booking {bookingId = bookPost.bookingId, BookingDateFrom = bookPost.BookingDateFrom, BookingDateTo = bookPost.BookingDateTo, Deposit = bookPost.Deposit, guestId = bookPost.guestId, roomId = bookPost.roomId, Status = bookPost.Status});

        [HttpPut]
        public Booking Put([FromBody] Booking bookPut) => _bookingRepo.UpdateBooking(bookPut);

        [HttpDelete("{id}")]
        public void Delete(int id) => _bookingRepo.DeleteBooking(_bookingRepo.GetBookings.Where(b => b.bookingId == id).Single());

        public IActionResult Index()
        {
            return View();
        }
    }
}
