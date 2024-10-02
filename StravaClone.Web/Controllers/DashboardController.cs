using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaClone.Web.Commands.Dashboard;
using StravaClone.Web.Queries.Dashboard;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetMyRacesAndClubsQuery();
            var result = await _mediator.Send(query);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> EditUserProfile()
        {
            var query = new GetProfileQuery();
            var result = await _mediator.Send(query);

            if (result == null) 
                return View("Error");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View(request);
            }

            var query = new EditProfileRequest(request);
            var result = await _mediator.Send(query);

            if(!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return View(request);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
