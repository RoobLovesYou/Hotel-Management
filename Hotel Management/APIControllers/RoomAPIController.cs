using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAPIController : Controller
    {
        /// <summary>
        /// Instance of Room Repository
        /// </summary>
        private IRoomRepo _RoomRepo;

        /// <summary>
        /// Constructor which takes existing RoomRepo to populate private field
        /// </summary>
        /// <param name="RoomRepo"></param>
        public RoomAPIController(IRoomRepo RoomRepo)
        {
            _RoomRepo = RoomRepo;
        }

        /// <summary>
        /// Uses HttpGet to get all rooms in repository
        /// </summary>
        /// <returns>IEnumerable containing all Rooms</returns>
        [HttpGet]
        public IEnumerable<Room> Get() => _RoomRepo.GetRooms;

        /// <summary>
        /// Gets Room by Id in repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Room> Get(int id)
        {
            if (id == 0)
                return BadRequest("Invalid ID");
            return Ok(_RoomRepo[id]);
        }

       
       
    }
}
