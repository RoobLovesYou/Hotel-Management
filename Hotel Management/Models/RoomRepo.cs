/* Author: Reuben Tudball
 * 
 * This is an interface for RoomRepo. 
 * 
 * 
 */

namespace Hotel_Management.Models
{
    public class RoomRepo : IRoomRepo
    {
        private HMContext _context;

        public RoomRepo(HMContext context)
        {
            _context = context;
        }  

        public Room this[int id] => _context.Rooms.Where(r => r.RoomId == id).Single();
        public IQueryable<Room> GetRooms => _context.Rooms;

        public Room AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return room;
        }

        public Room UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return room;
        }

        public void DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }
}
