namespace HotelApp.Models;

public class HotelBookingModel : IEntity
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public int ClientId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}