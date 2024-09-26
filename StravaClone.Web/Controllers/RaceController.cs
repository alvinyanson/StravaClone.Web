using Mapster;
using Microsoft.AspNetCore.Mvc;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RaceController(
            IRaceRepository raceRepository, 
            IPhotoService photoService,
            IHttpContextAccessor httpContextAccessor)
        {
            _raceRepository = raceRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
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

        public IActionResult Create()
        {
            var userId = _httpContextAccessor.HttpContext?.User.GetUserId();

            var createRaceViewModel = new CreateRaceViewModel
            {
                AppUserId = userId
            };

            return View(createRaceViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRaceViewModel request)
        {
            if (ModelState.IsValid)
            {

                var result = await _photoService.AddPhotoAsync(request.Image);

                var race = request.Adapt<Race>();
                race.Image = result.Url.ToString();

                _raceRepository.Add(race);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed");
            }

            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var race = await _raceRepository.GetByIdAsync(id);

            if (race == null) return View("Error");

            var clubVM = race.Adapt<EditRaceViewModel>();

            return View(clubVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRaceViewModel request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit race");
                return View(nameof(Edit), request);
            }

            var userClub = await _raceRepository.GetByIdAsyncNoTracking(id);

            if (userClub == null)
            {
                return View(request);
            }

            try
            {
                await _photoService.DeletePhotoAsync(userClub.Image);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Could not delete photo");
                return View(request);
            }

            var photoResult = await _photoService.AddPhotoAsync(request.Image);

            var race = request.Adapt<Race>();
            race.Image = photoResult.Url.ToString();

            _raceRepository.Update(race);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var raceDetail = await _raceRepository.GetByIdAsync(id);

            if (raceDetail == null) return View("Error");

            return View(raceDetail);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRace(int id)
        {
            var raceDetail = await _raceRepository.GetByIdAsync(id);

            if (raceDetail == null) return View("Error");

            _raceRepository.Delete(raceDetail);

            return RedirectToAction(nameof(Index));
        }
    }
}
