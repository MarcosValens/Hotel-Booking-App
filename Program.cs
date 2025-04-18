using HotelApp.Models;
using HotelApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var configJson = File.ReadAllText("config.json");
var config = JsonSerializer.Deserialize<AppConfigModel>(configJson)
    ?? throw new InvalidOperationException("Invalid config.json");

builder.Services.AddSingleton(config);

if (config.DATA_TYPE == "FS")
{
    builder.Services.AddSingleton(typeof(IRepositoryService<>), typeof(FsRepositoryService<>));
}
else if (config.DATA_TYPE == "DB")
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(config.DB_CONNECTION ?? "Data Source=hotelapp.db"));

    builder.Services.AddScoped(typeof(IRepositoryService<>), typeof(DbRepositoryService<>));
}

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (config.DATA_TYPE == "DB")
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    DbSeeder.Seed(db);
}

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();
