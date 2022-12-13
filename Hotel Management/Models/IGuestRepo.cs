namespace Hotel_Management.Models
{
    public interface IGuestRepo
    {
        IQueryable<Guest> GetGuests { get; }
        Guest this[int id] { get; }

        Guest AddGuest(Guest guest);
        Guest UpdateGuest(Guest guest);
        void DeleteGuest(Guest guest);

    }
}
