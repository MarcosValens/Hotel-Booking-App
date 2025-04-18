namespace HotelApp.Models;

public class HotelModel : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
}