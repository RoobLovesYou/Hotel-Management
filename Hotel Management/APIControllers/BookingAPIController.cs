using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

/* Author: Reuben Tudball
 * 
 * This is an API controller for Bookings. It handles all CRUD operations by utilizing the Booking Repository.
 * 
 * 
 */


namespace Hotel_Management.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingAPIController : Controller
    {
        /// <summary>
        /// Instance of the Booking Repository
        /// </summary>
        private IBookingRepo _bookingRepo;
        
        /// <summary>
        /// Constructor that takes booking repo passed between controllers. This populates _bookingRepo with data
        /// </summary>
        /// <param name="bookingRepo">Instance of Booking Repository</param>
        public BookingAPIController(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        /// <summary>
        /// Gets all bookings available from Booking Repository via HttpGet.
        /// </summary>
        /// <returns>IEnumerable of all Bookings</returns>
        [HttpGet]
        public IEnumerable<Booking> Get() => _bookingRepo.GetBookings;

        /// <summary>
        /// Gets single Booking by Id via HttpGet. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Booking with respective Id</returns>
        [HttpGet("{id}")]
        public ActionResult<Booking> Get(int id)
        {
            if(id == 0)
                return BadRequest("Invalid ID");
            return Ok(_bookingRepo[id]);
        }

        /// <summary>
        /// Adds a new booking to Repository via HttpPost.
        /// </summary>
        /// <param name="bookPost"></param>
        /// <returns>Booking added to Repository</returns>
        [HttpPost]
        public Booking Post([FromBody] Booking bookPost) => _bookingRepo.AddBooking(new Booking {bookingId = bookPost.bookingId, BookingDateFrom = bookPost.BookingDateFrom, BookingDateTo = bookPost.BookingDateTo, Deposit = bookPost.Deposit, guestId = bookPost.guestId, roomId = bookPost.roomId, Status = bookPost.Status});

        /// <summary>
        /// Updates an existing booking in Repostory via HttpPut
        /// </summary>
        /// <param name="bookPut"></param>
        /// <returns>Update Booking</returns>
        [HttpPut]
        public Booking Put([FromBody] Booking bookPut) => _bookingRepo.UpdateBooking(bookPut);

        /// <summary>
        /// Deletes an existing booking in Repository by Id. Uses HttpDelete.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id) => _bookingRepo.DeleteBooking(_bookingRepo.GetBookings.Where(b => b.bookingId == id).Single());


       
    }
}
