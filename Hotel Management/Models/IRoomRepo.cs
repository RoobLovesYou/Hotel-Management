namespace Hotel_Management.Models
{
    public interface IRoomRepo
    {
        //IQueryable<Room> GetRooms { get; }
        Room this[int id] { get; }
    }
}
