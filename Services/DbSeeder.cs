using HotelApp.Models;

namespace HotelApp.Services;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (!db.Clients.Any())
        {
            db.Clients.AddRange(
                new ClientModel { FullName = "Marcos Valens" },
                new ClientModel { FullName = "Maria Payeras" }
            );
        }

        if (!db.Hotels.Any())
        {
            db.Hotels.AddRange(
                new HotelModel { Name = "Hotel Melia Resort" },
                new HotelModel { Name = "Hotel Palas Atenea" }
            );
        }

        db.SaveChanges();
    }
}
