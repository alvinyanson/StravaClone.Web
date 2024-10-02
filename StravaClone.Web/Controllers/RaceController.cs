using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using StravaClone.Web.Commands.Races;
using StravaClone.Web.Queries.Races;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Controllers
{
    [Authorize]
    public class RaceController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;

        public RaceController(
            IHttpContextAccessor httpContextAccessor,
            IMediator mediator)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [OutputCache(PolicyName = "Expire20")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllRacesQuery();
            var result = await _mediator.Send(query);

            return View(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var query = new GetRaceDetailQuery(id);
            var result = await _mediator.Send(query);

            return View(result);
        }

        [HttpGet]
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
                var query = new CreateRaceRequest(request);
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
            var query = new GetRaceDetailQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) 
                return View("Error");

            var clubVM = result.Adapt<EditRaceViewModel>();

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

            var query = new EditRaceRequest(request);
            var result = await _mediator.Send(query);

            if(!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return View(request);
            }
            
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            var query = new GetRaceDetailQuery(id);
            var result = await _mediator.Send(query);

            if (result == null) 
                return View("Error");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRace(int id)
        {
            var query = new DeleteRaceRequest(id);
            var result = await _mediator.Send(query);

            if (!result)
                return View("Error");

            return RedirectToAction(nameof(Index));
        }
    }
}
