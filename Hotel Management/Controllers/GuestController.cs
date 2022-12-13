using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    public class GuestController : Controller
    {

        private IGuestRepo _guestRepo;

        public GuestController(IGuestRepo guestRepo)
        {
            _guestRepo = guestRepo;
        }

        [HttpGet]
        public IActionResult GuestHome()
        {
            return View(_guestRepo.GetGuests);
        }


        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _guestRepo.AddGuest(guest);
                return RedirectToAction("GuestHome");
            }
            return View("AddGuest");
        }

        [HttpGet]
        public IActionResult UpdateGuest(int id)
        {

            if (id == 0)
            {
                return View(new Guest());
            }

            return View(_guestRepo[id]);
        }

        [HttpPost]
        public IActionResult UpdateGuest(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _guestRepo.UpdateGuest(guest);
                return RedirectToAction("GuestHome");
            }
            return View("UpdateGuest");
        }

        [HttpPost, ActionName("DeleteGuest")]
        public IActionResult DeleteConfirm(int id)
        {
            var guest = _guestRepo[id];
            _guestRepo.DeleteGuest(guest);
            return RedirectToAction("GuestHome");
        }
    }
}
