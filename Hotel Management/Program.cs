using Hotel_Management.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<>();
builder.Services.AddScoped<IBookingRepo, BookingRepo>();
builder.Services.AddScoped<IGuestRepo, GuestRepo>();
builder.Services.AddScoped<IRoomRepo, RoomRepo>();


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

app.Run();

