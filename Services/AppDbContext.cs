using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Services;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ClientModel> Clients => Set<ClientModel>();
    public DbSet<HotelModel> Hotels => Set<HotelModel>();
    public DbSet<HotelBookingModel> HotelBookings => Set<HotelBookingModel>();
}
