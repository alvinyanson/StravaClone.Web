using Microsoft.AspNetCore.Mvc;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;

namespace StravaClone.Web.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            var clubs = await _clubRepository.GetAllAsync();

            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);

            return View(club);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Club club)
        {
            if(!ModelState.IsValid)
            {
                return View(club);
            }

            _clubRepository.Add(club);

            return RedirectToAction(nameof(Index));
        }
    }
}
