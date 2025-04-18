namespace HotelApp.Models;

public class ClientModel : IEntity
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
}