using Microsoft.EntityFrameworkCore;

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
                        Status = true,
                    },
                    new Booking
                    {
                      //  bookingId = 2,
                        BookingDateFrom = new DateTime(2022, 11, 15),
                        BookingDateTo = new DateTime(2022, 11, 20),
                        Deposit = 100,
                        Status = true
                    },
                    new Booking
                    {
                       // bookingId = 3,
                        BookingDateFrom = new DateTime(2023, 01, 8),
                        BookingDateTo = new DateTime(2023, 01, 14),
                        Deposit = 200,
                        Status = false
                    }
                );
               
              
                context.SaveChanges();
            }
        }
    }
}
