using Hotel_Management.Controllers;
using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementTest
{
    public class BookingTest
    {

        IBookingRepo _bookingRepo;


        [Test]
        public void canChangeAttribute()
        {
            var booking = new Booking { bookingId = 1, Deposit = 200, Status = true, BookingDateFrom = new DateTime(12,12,16), BookingDateTo=new DateTime(12,12,18)};
            booking.Status = false;


            Assert.AreEqual(false, booking.Status);
        }


    }
}
