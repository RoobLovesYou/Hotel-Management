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
        private IBookingRepo _bookingRepo;
        private IGuestRepo _guestRepo;
        private IRoomRepo _roomRepo;

        public BookingController(IBookingRepo bookingRepo, IGuestRepo guestRep, IRoomRepo roomRepo)
        {
            _bookingRepo = bookingRepo;
            _guestRepo = guestRep;
            _roomRepo = roomRepo;
        }

        
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



        [HttpGet]
        public IActionResult AddBooking()
        {
            AddBookingView abv = new AddBookingView();
            abv.guests = _guestRepo.GetGuests;
            abv.rooms = _roomRepo.GetRooms;
            return View(abv);
        }

        //[HttpPost]
        //public IActionResult AddBooking(Booking booking)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        _bookingRepo.AddBooking(booking);
        //        return RedirectToAction("BookingHome");
        //    }
        //    return View("AddBooking");
        //}


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

        //[HttpPost]
        //public IActionResult UpdateBooking(Booking booking)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _bookingRepo.UpdateBooking(booking);
        //        return RedirectToAction("BookingHome");
        //    }
        //    return View("UpdateBooking");
        //}

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




        [HttpPost, ActionName("DeleteBooking")]
        public IActionResult DeleteConfirm(int id)
        {
            var booking = _bookingRepo[id];
            _bookingRepo.DeleteBooking(booking);
            return RedirectToAction("BookingHome");
        }

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
