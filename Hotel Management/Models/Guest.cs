﻿/* Author: Hoorya Rafiq
 * 
 * This is an  model class for Guests. 
 * 
 * 
 */
namespace Hotel_Management.Models
{
    public class Guest
    {
        public int guestId { get; set; }
        public string guestName { get; set; }
        public string guestPhoneNo { get; set; }
        public string guestEmail { get; set; }

       // public List<Booking> bookings { get; set; }

        //could add checkedIn bool? 
    }
}
