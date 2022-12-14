/* Author: Reuben Tudball
 * 
 * This is an model class for Rooms. 
 * 
 * 
 */
namespace Hotel_Management.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public enum RoomType
        {
            Single,
            Double,
            Deluxe,
            Suite
            //add room types here
        }
        public RoomType roomType { get; set; }
        public bool isOccupied { get; set; }
        public int RoomCapacity { get; set; }

        //public Image RoomImage { get; set; } TODO figure out best way to have image as an attribute.
        public string RoomDescription { get; set; }
    }
}
