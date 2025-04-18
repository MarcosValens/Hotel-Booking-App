using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelApp.Models;

public class HotelBookingFormViewModel
{
    public HotelBookingModel Booking { get; set; } = new();
    public List<SelectListItem> Hotels { get; set; } = new();
    public List<SelectListItem> Clients { get; set; } = new();
}
