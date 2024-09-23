using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.Repository;
using StravaClone.Web.Services;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IPhotoService _photoService;

        public RaceController(IRaceRepository raceRepository, IPhotoService photoService)
        {
            _raceRepository = raceRepository;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            var races = await _raceRepository.GetAllAsync();

            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var club = await _raceRepository.GetByIdAsync(id);

            return View(club);
        }

        public async Task<IActionResult> Create(CreateRaceViewModel request)
        {
            if (ModelState.IsValid)
            {

                var result = await _photoService.AddPhotoAsync(request.Image);

                var race = new Race
                {
                    Title = request.Title,
                    Description = request.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = request.Address.Street,
                        City = request.Address.City,
                        State = request.Address.State
                    }
                };

                _raceRepository.Add(race);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed");
            }

            return View(request);
        }
    }
}
