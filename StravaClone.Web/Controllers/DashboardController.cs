using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaClone.Web.Interfaces;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(
            IHttpContextAccessor httpContextAccessor,
            IPhotoService photoService,
            IUnitOfWork unitOfWork
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();

            var userRaces = await _unitOfWork.Dashboard.GetAllUserRaces(currentUser.ToString());
            var userClubs = await _unitOfWork.Dashboard.GetAllUserClubs(currentUser.ToString());

            var dashboardVM = new DashboardViewModel
            {
                Races = userRaces,
                Clubs = userClubs,
            };

            return View(dashboardVM);
        }


        public async Task<IActionResult> EditUserProfile()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();

            var user = await _unitOfWork.Dashboard.GetUserById(userId);

            if (user == null) return View("Error");

            var editUserViewModel = user.Adapt<EditUserDashboardViewModel>();

            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View(request);
            }

            var user = await _unitOfWork.Dashboard.GetByIdNoTracking(request.Id);
            
            var photoResult = await _photoService.AddPhotoAsync(request.Image);

            if (user.ProfileImageUrl == "" || user.ProfileImageUrl == null)
            {
                user.Adapt(request);
                user.ProfileImageUrl = photoResult.Url.ToString();

                _unitOfWork.Dashboard.Update(user);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                try
                {
                    await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(request);
                }

                user.Adapt(request);

                user.ProfileImageUrl = photoResult.Url.ToString();

                _unitOfWork.Dashboard.Update(user);

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
