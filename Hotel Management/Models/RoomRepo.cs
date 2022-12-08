namespace Hotel_Management.Models
{
    public class RoomRepo : IRoomRepo
    {
        public Room this[int id] => new Room { };
        // public IQueryable<Room> GetRooms => TODO
    }
}
