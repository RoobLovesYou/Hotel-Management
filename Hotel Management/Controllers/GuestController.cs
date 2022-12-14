using Hotel_Management.Models;
using Hotel_Management.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotel_Management.Controllers
{
    public class GuestController : Controller
    {

        private IGuestRepo _guestRepo;
        private IBookingRepo _bookingRepo;

        public GuestController(IGuestRepo guestRepo, IBookingRepo bookingRepo)
        {
            _guestRepo = guestRepo;
            _bookingRepo = bookingRepo;
        }

        
        public async Task<IActionResult> GuestHome()
        {
            List<Guest> guests = new List<Guest>();
            using(HttpClient client = new HttpClient())
            {
                using(var response = await client.GetAsync("https://localhost:7000/api/guestapi"))
                {
                    string apiResp = await response.Content.ReadAsStringAsync();
                    guests = JsonConvert.DeserializeObject<List<Guest>>(apiResp);
                }
            }

            return View(guests);
        }


        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuest(Guest guest)
        {
           Guest guestToAdd = new Guest();
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(guest), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7000/api/guestapi",content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResp = await response.Content.ReadAsStringAsync();
                        guestToAdd = JsonConvert.DeserializeObject<Guest>(apiResp);
                    }
                    else
                    {
                        ViewBag.StatusCode = Response.StatusCode;
                    }
                }
            }
            return RedirectToAction("GuestHome");
        }

        public async Task<IActionResult> UpdateGuest(int id)
        {
            Guest getGuest = new Guest();
            using (var httpClient = new HttpClient())
            {
                using (var resp = await httpClient.GetAsync("https://localhost:7000/api/guestapi/" + id))
                {
                    string apiResp = await resp.Content.ReadAsStringAsync();

                    getGuest = JsonConvert.DeserializeObject<Guest>(apiResp);
                }
            }
            return View(getGuest);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(Guest guest)
        {
            Guest getGuest = new Guest();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(guest), Encoding.UTF8, "application/json");
                using (var resp = await httpClient.PutAsync("https://localhost:7000/api/guestapi", content))
                {
                    string apiRes = await resp.Content.ReadAsStringAsync();

                    getGuest = JsonConvert.DeserializeObject<Guest>(apiRes);

                }
            }
            return RedirectToAction("GuestHome");
        }

        [HttpPost, ActionName("DeleteGuest")]
        public IActionResult DeleteConfirm(int id)
        {
            var guest = _guestRepo[id];
            _guestRepo.DeleteGuest(guest);
            return RedirectToAction("GuestHome");
        }

        [HttpGet]
        public IActionResult GuestBookings(int id)
        {
            GuestBookingView bookingListView = new GuestBookingView();
            bookingListView.guest = _guestRepo[id];
            bookingListView.bookings = _bookingRepo.GetBookings.Where(b => b.guestId == bookingListView.guest.guestId);


            return View(bookingListView);
        }

        
    }
}
