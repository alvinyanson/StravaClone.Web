using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Controllers
{
    [Authorize]
    public class RaceController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;
        private readonly IUnitOfWork _unitOfWork;

        public RaceController(
            IHttpContextAccessor httpContextAccessor,
            IPhotoService photoService,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [OutputCache(PolicyName = "Expire20")]
        public async Task<IActionResult> Index()
        {
            var races = await _unitOfWork.Race.GetAllAsync();

            return View(races);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            var club = await _unitOfWork.Race.GetByIdAsync(id);

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

                _unitOfWork.Race.Add(race);

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
            var race = await _unitOfWork.Race.GetByIdAsync(id);

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

            var userClub = await _unitOfWork.Race.GetByIdAsyncNoTracking(id);

            if (userClub == null)
                return View(request);

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

            _unitOfWork.Race.Update(race);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var raceDetail = await _unitOfWork.Race.GetByIdAsync(id);

            if (raceDetail == null) 
                return View("Error");

            return View(raceDetail);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRace(int id)
        {
            var raceDetail = await _unitOfWork.Race.GetByIdAsync(id);

            if (raceDetail == null) return View("Error");

            _unitOfWork.Race.Delete(raceDetail);

            return RedirectToAction(nameof(Index));
        }
    }
}
