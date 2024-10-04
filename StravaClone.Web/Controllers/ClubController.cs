using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using StravaClone.Web.Commands.Club;
using StravaClone.Web.Queries.Clubs;
using StravaClone.Entities.ViewModels;

namespace StravaClone.Web.Controllers
{
    [Authorize]
    public class ClubController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;

        public ClubController(
            IHttpContextAccessor httpContextAccessor,
            IMediator mediator
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [OutputCache(PolicyName = "Expire20")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllClubsQuery();
            var result = await _mediator.Send(query);

            return View(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var query = new GetClubDetailQuery(id);
            var result = await _mediator.Send(query);

            return View(result);
        }

        public IActionResult Create()
        {
            var userid = _httpContextAccessor.HttpContext.User.GetUserId();

            var createClubViewModel = new CreateClubViewModel
            {
                AppUserId = userid,
            };

            return View(createClubViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClubViewModel request)
        {
            if (ModelState.IsValid)
            {
                var query = new CreateClubRequest(request);
                var result = await _mediator.Send(query);
                
                return RedirectToAction(nameof(Index));
            }
            else
                ModelState.AddModelError("", "Photo Upload Failed");

            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var query = new GetClubDetailQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) 
                return View("Error");

            var clubVM = result.Adapt<EditClubViewModel>();

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

            var query = new EditClubRequest(request);
            var result = await _mediator.Send(query);

            if(!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage!);
                return View(nameof(Edit), request);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new GetClubDetailQuery(id);
            var result = await _mediator.Send(query);

            if(result == null)
                return View("Error");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var query = new DeleteClubRequest(id);
            var result = await _mediator.Send(query);

            if(!result)
                return View("Error");

            return RedirectToAction(nameof(Index));
        }

    }
}
