using HotelApp.Models;
using HotelApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelApp.Controllers;

public class HotelBookingController : Controller
{
    private readonly IRepositoryService<HotelBookingModel> _repo;
    private readonly IRepositoryService<ClientModel> _clientRepo;
    private readonly IRepositoryService<HotelModel> _hotelRepo;

    public HotelBookingController(IRepositoryService<HotelBookingModel> repo,
                                  IRepositoryService<ClientModel> clientRepo,
                                  IRepositoryService<HotelModel> hotelRepo)
    {
        _repo = repo;
        _clientRepo = clientRepo;
        _hotelRepo = hotelRepo;
    }

    public IActionResult Index()
    {
        var bookings = _repo.GetAll().ToList();
        return View(bookings);
    }

    public IActionResult Create()
    {
        var viewModel = new HotelBookingFormViewModel
        {
            Booking = new HotelBookingModel(),
            Hotels = _hotelRepo.GetAll()
                .Select(h => new SelectListItem { Value = h.Id.ToString(), Text = h.Name })
                .ToList(),
            Clients = _clientRepo.GetAll()
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.FullName })
                .ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(HotelBookingFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Hotels = _hotelRepo.GetAll()
                .Select(h => new SelectListItem { Value = h.Id.ToString(), Text = h.Name }).ToList();
            viewModel.Clients = _clientRepo.GetAll()
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.FullName }).ToList();

            return View(viewModel);
        }

        _repo.Add(viewModel.Booking);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var booking = _repo.GetById(id);
        if (booking == null) return NotFound();

        var viewModel = new HotelBookingFormViewModel
        {
            Booking = booking,
            Hotels = _hotelRepo.GetAll()
                .Select(h => new SelectListItem { Value = h.Id.ToString(), Text = h.Name })
                .ToList(),
            Clients = _clientRepo.GetAll()
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.FullName })
                .ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Edit(int id, HotelBookingFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Hotels = _hotelRepo.GetAll()
                .Select(h => new SelectListItem { Value = h.Id.ToString(), Text = h.Name }).ToList();
            viewModel.Clients = _clientRepo.GetAll()
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.FullName }).ToList();

            return View(viewModel);
        }

        _repo.Update(id, viewModel.Booking);
        return RedirectToAction(nameof(Index));
    }
}
