using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAPIController : Controller
    {
        private IRoomRepo _RoomRepo;

        public RoomAPIController(IRoomRepo RoomRepo)
        {
            _RoomRepo = RoomRepo;
        }

        [HttpGet]
        public IEnumerable<Room> Get() => _RoomRepo.GetRooms;

        [HttpGet("{id}")]
        public ActionResult<Room> Get(int id)
        {
            if (id == 0)
                return BadRequest("Invalid ID");
            return Ok(_RoomRepo[id]);
        }

       
        public IActionResult Index()
        {
            return View();
        }
    }
}
