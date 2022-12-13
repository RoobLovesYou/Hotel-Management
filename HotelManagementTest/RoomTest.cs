using Hotel_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementTest
{
    public class RoomTest
    {

        [Test]
        public void CanChangeAttribute()
        {
            Room room = new Room { RoomId = 1, RoomCapacity = 2, roomType = Room.RoomType.Single, isOccupied=false, Price=200, RoomDescription="This is a room description"};
            room.Price = 400;

            Assert.That(room.Price, Is.EqualTo(400));
        }
    }
}
