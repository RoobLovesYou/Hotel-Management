using Hotel_Management.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HMContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DBStr"]));
builder.Services.AddScoped<IBookingRepo, BookingRepo>();
builder.Services.AddScoped<IGuestRepo, GuestRepo>();
builder.Services.AddScoped<IRoomRepo, RoomRepo>();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

//SampleData.LoadData(app);

app.Run();

