﻿using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
/* Author: Hoorya Rafiq
 * 
 * This is an controller for Rooms. It handles all CRUD operations by utilizing the Room Repository.
 * 
 * 
 */


namespace Hotel_Management.Controllers
{
    public class RoomController : Controller
    {
      


        /// <summary>
        /// Gets all Rooms in Database via HttpGet API call
        /// </summary>
        /// <returns>View of IEnumerable<Rooms></returns>
        public async Task<IActionResult> RoomHome()
        {
            List<Room> rooms = new List<Room>();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7000/api/roomapi"))
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    rooms = JsonConvert.DeserializeObject<List<Room>>(resp);
                }
            }
            return View(rooms);

          
        }

        /// <summary>
        /// Gets specific Room in Database via Id. Uses HttpGet
        /// </summary>
        /// <param name="roomNo"></param>
        /// <returns>List of Rooms with Id</returns>
        [HttpPost]
        public async Task<IActionResult> RoomHome(string roomNo)
        {
            List<Room> rooms = new List<Room>();
            int result = Int32.Parse(roomNo);
            using (var httpClient = new HttpClient())
            {
                using (var resp = await httpClient.GetAsync("https://localhost:7000/api/roomapi/" + result))
                {
                    string apiResp = await resp.Content.ReadAsStringAsync();
                    rooms.Add(JsonConvert.DeserializeObject<Room>(apiResp));
                }
            }
            return View(rooms);
           // return View(_roomRepo.GetRooms.Where(r => r.RoomId == result));
        }
    }
}
