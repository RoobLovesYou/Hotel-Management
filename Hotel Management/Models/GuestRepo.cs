using Microsoft.EntityFrameworkCore;

/* Author: Hoorya Rafiq
 * 
 * This is an model class for RoomRepo. 
 * 
 * 
 */

namespace Hotel_Management.Models
{
    public class GuestRepo : IGuestRepo
    {
        private HMContext _context;

        public GuestRepo(HMContext context)
        {
            _context = context;
        }

        public Guest this[int id] => _context.Guests.Where(g => g.guestId == id).Single();
        
        public Guest AddGuest(Guest guest)
        {
            _context.Guests.Add(guest);
            _context.SaveChanges();
            return guest;

        }
        public Guest UpdateGuest(Guest guest)
        {
            _context.Guests.Update(guest);
            _context.SaveChanges();
            return guest;
        }
        public void DeleteGuest(Guest guest)
        {
            _context.Guests.Remove(guest);
            _context.SaveChanges();

        }

        public IQueryable<Guest> GetGuests => _context.Guests;

    }
}

