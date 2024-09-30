using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.Queries;
using StravaClone.Web.ViewModels;
using System.Diagnostics;

namespace StravaClone.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IIPInfoService _IPInfoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public HomeController(
            IIPInfoService IPInfoService,
            IUnitOfWork unitOfWork,
            IMediator mediator
            )
        {
            _IPInfoService = IPInfoService;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllClubsNearMeQuery();

            var clubsNearMe = await _mediator.Send(query);

            return View(clubsNearMe);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
