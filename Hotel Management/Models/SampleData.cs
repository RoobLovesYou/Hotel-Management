﻿using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Models
{
    public class SampleData
    {
        public static void LoadData(IApplicationBuilder app)
        {
            HMContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<HMContext>();
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            else
            {
                context.Guests.AddRange(
                  new Guest
                  {
                      // guestId = 1,
                      guestName = "John Smith",
                      guestPhoneNo = "647-443-1883",
                      guestEmail = "John@outlook.com"
                  },
                  new Guest
                  {
                      //   guestId = 2,
                      guestName = "Louise Williams ",
                      guestPhoneNo = "416-903-3018",
                      guestEmail = "Louise@gmail.com"
                  },
                  new Guest
                  {
                      //  guestId = 3,
                      guestName = "Joe Brown ",
                      guestPhoneNo = "905-721-4451",
                      guestEmail = "Joe@outlook.com"
                  }
                );
                context.Bookings.AddRange(
                    new Booking
                    {
                        //  bookingId = 1,
                        BookingDateFrom = new DateTime(2022, 12, 1),
                        BookingDateTo = new DateTime(2022, 12, 6),
                        Deposit = 150,
                        guestId = 1,
                        Status = true,
                    },
                    new Booking
                    {
                        //  bookingId = 2,
                        BookingDateFrom = new DateTime(2022, 11, 15),
                        BookingDateTo = new DateTime(2022, 11, 20),
                        Deposit = 100,
                        guestId = 2,
                        Status = true
                    },
                    new Booking
                    {
                        // bookingId = 3,
                        BookingDateFrom = new DateTime(2023, 01, 8),
                        BookingDateTo = new DateTime(2023, 01, 14),
                        Deposit = 200,
                        guestId = 2,
                        Status = false
                    }
                );
                context.Rooms.AddRange(
                    new Room
                    {
                      //  RoomId = 1,
                        Price = 132,
                        roomType = Room.RoomType.Single,
                        isOccupied = false,
                        RoomCapacity = 2,
                        RoomDescription = "Upscale hotel offering Standard Single room"
                    },
                    new Room
                    {
                      //  RoomId = 2,
                        Price = 148,
                        roomType = Room.RoomType.Double,
                        isOccupied = false,
                        RoomCapacity = 2,
                        RoomDescription = "Upscale hotel offering Standard Double room"
                    },
                    new Room
                    {
                      //  RoomId = 3,
                        Price = 163,
                        roomType = Room.RoomType.Deluxe,
                        isOccupied = false,
                        RoomCapacity = 4,
                        RoomDescription = "Upscale hotel offering Deluxe room with High-end Amenities"
                    },
                    new Room
                    {
                      //  RoomId = 4,
                        Price = 181,
                        roomType = Room.RoomType.Suite,
                        isOccupied = true,
                        RoomCapacity = 4,
                        RoomDescription = "Upscale hotel offering Suite room with Separate Kitchen, Dining, Living Areas"
                    }
                );
              
                context.SaveChanges();
            }
        }
    }
}
