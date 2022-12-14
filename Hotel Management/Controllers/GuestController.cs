using Hotel_Management.Models;
using Hotel_Management.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
/* Author: Hoorya Rafiq
 * 
 * This is an controller for Guests. It handles all CRUD operations by utilizing the Guest Repository.
 * 
 * 
 */


namespace Hotel_Management.Controllers
{
    public class GuestController : Controller
    {
        /// <summary>
        /// Instance of Guest Repository
        /// </summary>
        private IGuestRepo _guestRepo;

        /// <summary>
        /// Instance of Booking Repository
        /// </summary>
        private IBookingRepo _bookingRepo;

        /// <summary>
        /// Constructor that takes a Booking Repository and Guest Repository. Populates fields with data
        /// </summary>
        /// <param name="bookingRepo"></param>
        /// <param name="guestRep"></param>
        public GuestController(IGuestRepo guestRepo, IBookingRepo bookingRepo)
        {
            _guestRepo = guestRepo;
            _bookingRepo = bookingRepo;
        }

        /// <summary>
        /// Asynchronously calls the GuestAPIs Get() function. Returns all Guests in DB.
        /// </summary>
        /// <returns>All Guests as List</returns>
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

        /// <summary>
        /// Directs to AddGuest view
        /// </summary>
        /// <returns>AddGuest view</returns>
        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }

        /// <summary>
        /// Asynchronously Adds Guest to Database via HttpPost Api all.
        /// </summary>
        /// <param name="guest"></param>
        /// <returns>IActionResult which redirects back to GuestHome</returns>
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

        /// <summary>
        /// Asynchronously gets existing Guest to be updated in Database via Id using HttpGet. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Guest to be updated</returns>
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

        /// <summary>
        /// Asynchronously updates existing Guest in Database via HttpPut API call.
        /// </summary>
        /// <param name="guest"></param>
        /// <returns>IActionResult which redirects back to Guest Home</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateGuest(Guest guest)
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

        /// <summary>
        /// Deletes Guest via Id in Repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult which redirects back to GuestHome</returns>
        [HttpPost, ActionName("DeleteGuest")]
        public IActionResult DeleteConfirm(int id)
        {
            var guest = _guestRepo[id];
            _guestRepo.DeleteGuest(guest);
            return RedirectToAction("GuestHome");
        }

        /// <summary>
        /// Gets all Bookings of respective guest via GuestBookingView View Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult of bookingListView</returns>
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
