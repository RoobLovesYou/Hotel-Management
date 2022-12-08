namespace Hotel_Management.Models
{
    public class GuestRepo : IGuestRepo
    {
        public Guest this[int id] => new Guest { };
        // public IQueryable<Guest> GetGuests => TODO
        public Guest AddGuest(Guest guest)
        {
            return null;

        }
        public Guest UpdateGuest(Guest guest)
        {
            return null;
        }
        public void DeleteGuest(Guest guest)
        {

        }

       

    }
}
}
