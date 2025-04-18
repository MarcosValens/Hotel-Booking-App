using HotelApp.Models;
using HotelApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers;

public class HotelController(IRepositoryService<HotelModel> repo) : Controller
{
    private readonly IRepositoryService<HotelModel> _repo = repo;

    public IActionResult Index()
    {
        var hotels = _repo.GetAll().ToList();
        return View(hotels);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(HotelModel hotel)
    {
        if (!ModelState.IsValid)
            return View(hotel);

        _repo.Add(hotel);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var hotel = _repo.GetById(id);
        if (hotel == null) return NotFound();
        return View(hotel);
    }

    [HttpPost]
    public IActionResult Edit(int id, HotelModel hotel)
    {
        if (!ModelState.IsValid)
            return View(hotel);

        _repo.Update(id, hotel);
        return RedirectToAction(nameof(Index));
    }
}
