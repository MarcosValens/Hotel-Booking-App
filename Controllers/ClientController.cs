using HotelApp.Models;
using HotelApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers;

public class ClientController(IRepositoryService<ClientModel> repo) : Controller
{
    private readonly IRepositoryService<ClientModel> _repo = repo;

    public IActionResult Index()
    {
        var clients = _repo.GetAll().ToList();
        return View(clients);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ClientModel client)
    {
        if (!ModelState.IsValid)
            return View(client);

        _repo.Add(client);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var client = _repo.GetById(id);
        if (client == null) return NotFound();

        return View(client);
    }

    [HttpPost]
    public IActionResult Edit(int id, ClientModel client)
    {
        if (!ModelState.IsValid)
            return View(client);

        _repo.Update(id, client);
        return RedirectToAction(nameof(Index));
    }
}
