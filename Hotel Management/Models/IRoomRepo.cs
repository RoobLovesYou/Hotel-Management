/* Author: Reuben Tudball
 * 
 * This is an interface for RoomRepo. 
 * 
 * 
 */

namespace Hotel_Management.Models
{
    public interface IRoomRepo
    {
        IQueryable<Room> GetRooms { get; }
        Room this[int id] { get; }
    }
}
