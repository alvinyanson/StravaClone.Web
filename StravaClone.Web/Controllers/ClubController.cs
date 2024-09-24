using Microsoft.AspNetCore.Mvc;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;

        public ClubController(IClubRepository clubRepository, IPhotoService photoService)
        {
            _clubRepository = clubRepository;
            _photoService = photoService;
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
        public async Task<IActionResult> Create(CreateClubViewModel request)
        {
            if (ModelState.IsValid)
            {

                var result = await _photoService.AddPhotoAsync(request.Image);

                var club = new Club
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

                _clubRepository.Add(club);

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
            var club = await _clubRepository.GetByIdAsync(id);

            if (club == null) return View("Error");

            var clubVM = new EditClubViewModel
            {
                Title = club.Title,
                Description = club.Description,
                AddressId = club.AddressId,
                Address = club.Address,
                URL = club.Image,
                ClubCategory = club.ClubCategory,
            };

            return View(clubVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditClubViewModel request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View(nameof(Edit), request);
            }

            var userClub = await _clubRepository.GetByIdAsyncNoTracking(id);

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

            var club = new Club
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                Image = photoResult.Url.ToString(),
                AddressId = request.AddressId,
                Address = request.Address
            };

            _clubRepository.Update(club);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var clubDetail = await _clubRepository.GetByIdAsync(id);
            
            if(clubDetail == null) return View("Error");

            return View(clubDetail);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var clubDetail = await _clubRepository.GetByIdAsync(id);

            if (clubDetail == null) return View("Error");

            _clubRepository.Delete(clubDetail);

            return RedirectToAction(nameof(Index));
        }

    }
}
