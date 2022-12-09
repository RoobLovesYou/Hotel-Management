using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Models
{
    public class GuestRepo : IGuestRepo
    {
        private HMContext _context;
        public Guest this[int id] => _context.Guests.Where(g => g.guestId == id).Single();
        public IQueryable<Guest> GetGuests => _context.Guests;

       
        public Guest AddGuest(Guest guest)
        {
            _context.Guests.Add(guest);
            return guest;

        }
        public Guest UpdateGuest(Guest guest)
        {
            _context.Guests.Update(guest);
            return guest;
        }
        public void DeleteGuest(Guest guest)
        {
            _context?.Guests.Remove(guest);

        }

       

    }
}

