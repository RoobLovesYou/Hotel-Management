using Hotel_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementTest
{
    public class GuestTest
    {
        [Test]
        public void canChangeAttribute()
        {
            var guest = new Guest { guestId = 1, guestName="TestName", guestEmail="test@testing.com", guestPhoneNo="123-456-7890"};
            guest.guestName = "NameChange";


            Assert.That(guest.guestName, Is.EqualTo("NameChange"));
        }

    }
}
