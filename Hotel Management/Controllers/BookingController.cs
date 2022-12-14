using Hotel_Management.Models;
using Hotel_Management.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Hotel_Management.Controllers
{
    public class BookingController : Controller
    {
        /// <summary>
        /// Instance of Booking Repository
        /// </summary>
        private IBookingRepo _bookingRepo;

        /// <summary>
        /// instance of Guest Repository
        /// </summary>
        private IGuestRepo _guestRepo;

        /// <summary>
        /// instance of Room Repository
        /// </summary>
        private IRoomRepo _roomRepo;

        /// <summary>
        /// Constructor that takes each of the repositories passed from controllers as arguments. Populates fields with data
        /// </summary>
        /// <param name="bookingRepo"></param>
        /// <param name="guestRep"></param>
        /// <param name="roomRepo"></param>
        public BookingController(IBookingRepo bookingRepo, IGuestRepo guestRep, IRoomRepo roomRepo)
        {
            _bookingRepo = bookingRepo;
            _guestRepo = guestRep;
            _roomRepo = roomRepo;
        }

        /// <summary>
        /// Asynchronously calls the BookingAPIs Get() function. Returns all Bookings in DB.
        /// </summary>
        /// <returns>All Bookings as List</returns>
        public async Task<IActionResult> BookingHome()
        {
            List<Booking> bookings = new List<Booking>();
            using(HttpClient client = new HttpClient())
            {
                using(var response = await client.GetAsync("https://localhost:7000/api/bookingapi"))
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    bookings = JsonConvert.DeserializeObject<List<Booking>>(resp);
                }
            }
            return View(bookings);
        }


        /// <summary>
        /// Instantiates AddBookingView ViewModel. This allows for all Guests and Rooms to be accessed in AddBooking
        /// </summary>
        /// <returns>AddBookingView ViewModel</returns>
        [HttpGet]
        public IActionResult AddBooking()
        {
            AddBookingView abv = new AddBookingView();
            abv.guests = _guestRepo.GetGuests;
            abv.rooms = _roomRepo.GetRooms;
            return View(abv);
        }

        /// <summary>
        /// Asynchronously Adds Booking to Database via HttpPost API call.
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>Redirect back to BookingHome</returns>
        [HttpPost]
        public async Task<IActionResult> AddBooking(Booking booking)
        {
            Booking bookingToAdd = new Booking();
            using (HttpClient httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7000/api/bookingapi",content))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResonse = await response.Content.ReadAsStringAsync();
                        bookingToAdd = JsonConvert.DeserializeObject<Booking>(apiResonse);
                    }
                    else
                    {
                        ViewBag.StatusCode = Response.StatusCode;
                    }
                }
            }
            return RedirectToAction("BookingHome");
        }


        /// <summary>
        /// Asynchronously gets existing Booking in Database via HttpGet API call with Id. This Booking will be updated.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Booking to be updated</returns>
        public async Task<IActionResult> UpdateBooking(int id)
        {
            Booking getBook = new Booking();
            using (var httpClient = new HttpClient())
            {
                using (var resp = await httpClient.GetAsync("https://localhost:7000/api/bookingapi/" + id))
                {
                    string apiBook = await resp.Content.ReadAsStringAsync();
                    
                    getBook = JsonConvert.DeserializeObject<Booking>(apiBook);
                }
            }
            return View(getBook);
        }

        /// <summary>
        /// Asynchronously updates existing Booking in Database via HttpPut API call.
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>Redirect back to BookingHome</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(Booking booking)
        {
            Booking getBook = new Booking();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                using (var resp = await httpClient.PutAsync("https://localhost:7000/api/bookingapi", content))
                {
                    string apiRes = await resp.Content.ReadAsStringAsync();

                    getBook = JsonConvert.DeserializeObject<Booking>(apiRes);
                    
                }
            }
            return RedirectToAction("BookingHome");
        }



        /// <summary>
        /// Deletes Booking by ID in Repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult that redirects back to BookingHome</returns>
        [HttpPost, ActionName("DeleteBooking")]
        public IActionResult DeleteConfirm(int id)
        {
            var booking = _bookingRepo[id];
            _bookingRepo.DeleteBooking(booking);
            return RedirectToAction("BookingHome");
        }

        /// <summary>
        /// Gets complete Booking details, including respective Room and Guest via the BookingDetailsView ViewModel.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BookingDetailsView</returns>
        [HttpGet]
        public IActionResult BookingDetails(int id)
        {
            BookingDetailsView bookingDetailsView = new BookingDetailsView();
            bookingDetailsView.booking = _bookingRepo[id];
            bookingDetailsView.guest = _guestRepo[bookingDetailsView.booking.guestId];
            bookingDetailsView.room = _roomRepo[bookingDetailsView.booking.roomId];

            return View(bookingDetailsView);
        }


    }
}
