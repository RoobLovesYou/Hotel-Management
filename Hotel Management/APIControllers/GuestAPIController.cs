using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

/* Author: Hoorya Rafiq
 * 
 * This is an API controller for Guests. It handles all CRUD operations by utilizing the Guest Repository.
 * 
 * 
 */


namespace Hotel_Management.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestAPIController : Controller
    {
        /// <summary>
        /// Instance of Guest Repository
        /// </summary>
        private IGuestRepo _GuestRepo;

        /// <summary>
        /// Constructor that takes Guest Repository passed between controllers. Populates _GuestRepo with data.
        /// </summary>
        /// <param name="GuestRepo"></param>
        public GuestAPIController(IGuestRepo GuestRepo)
        {
            _GuestRepo = GuestRepo;
        }

        /// <summary>
        /// Uses HttpGet to get all Guests currently in repository
        /// </summary>
        /// <returns>IEnumurable of all Guests in repo</returns>
        [HttpGet]
        public IEnumerable<Guest> Get() => _GuestRepo.GetGuests;

        /// <summary>
        /// Gets Guest by Id using HttpGet
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult of Guest</returns>
        [HttpGet("{id}")]
        public ActionResult<Guest> Get(int id)
        {
            if (id == 0)
                return BadRequest("Invalid ID");
            return Ok(_GuestRepo[id]);
        }

        /// <summary>
        /// Adds a new Guest to repository using HttpPost
        /// </summary>
        /// <param name="guestPost"></param>
        /// <returns>Guest added to Repository</returns>
        [HttpPost]
        public Guest Post([FromBody] Guest guestPost) => _GuestRepo.AddGuest(new Guest { guestId = guestPost.guestId, guestEmail = guestPost.guestEmail, guestName = guestPost.guestName, guestPhoneNo = guestPost.guestPhoneNo});

        /// <summary>
        /// Updates an existing Guest in repository using HttpPut
        /// </summary>
        /// <param name="guestPut"></param>
        /// <returns>Update Guest</returns>
        [HttpPut]
        public Guest Put([FromBody] Guest guestPut) => _GuestRepo.UpdateGuest(guestPut);

        /// <summary>
        /// Deletes existing Guest in repository by Id. Uses HttpDelete
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id) => _GuestRepo.DeleteGuest(_GuestRepo.GetGuests.Where(g => g.guestId == id).Single());

       
    }
}
