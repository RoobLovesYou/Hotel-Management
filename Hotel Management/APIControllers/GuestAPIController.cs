using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestAPIController : Controller
    {
        private IGuestRepo _GuestRepo;

        public GuestAPIController(IGuestRepo GuestRepo)
        {
            _GuestRepo = GuestRepo;
        }

        [HttpGet]
        public IEnumerable<Guest> Get() => _GuestRepo.GetGuests;

        [HttpGet("{id}")]
        public ActionResult<Guest> Get(int id)
        {
            if (id == 0)
                return BadRequest("Invalid ID");
            return Ok(_GuestRepo[id]);
        }

        [HttpPost]
        public Guest Post([FromBody] Guest guestPost) => _GuestRepo.AddGuest(new Guest { guestId = guestPost.guestId, guestEmail = guestPost.guestEmail, guestName = guestPost.guestName, guestPhoneNo = guestPost.guestPhoneNo});

        [HttpPut]
        public Guest Put([FromBody] Guest guestPut) => _GuestRepo.UpdateGuest(guestPut);

        [HttpDelete("{id}")]
        public void Delete(int id) => _GuestRepo.DeleteGuest(_GuestRepo.GetGuests.Where(g => g.guestId == id).Single());

        public IActionResult Index()
        {
            return View();
        }
    }
}
