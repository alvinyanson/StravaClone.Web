using Microsoft.AspNetCore.Mvc;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;

namespace StravaClone.Web.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;

        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
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

        public IActionResult Create(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View(race);
            }

            _raceRepository.Add(race);

            return RedirectToAction(nameof(Index));
        }
    }
}
