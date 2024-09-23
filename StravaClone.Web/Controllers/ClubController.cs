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
    }
}
