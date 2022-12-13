using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
    public class RoomController : Controller
    {
        private IRoomRepo _roomRepo;

        public RoomController(IRoomRepo roomRepo)
        {
            _roomRepo = roomRepo;
        }

        [HttpGet]
        public IActionResult RoomHome()
        {
            return View(_roomRepo.GetRooms);
        }


        [HttpPost]
        public IActionResult RoomHome(string roomNo)
        {
            int result = Int32.Parse(roomNo);
            return View(_roomRepo.GetRooms.Where(r => r.RoomId == result));
        }
    }
}
