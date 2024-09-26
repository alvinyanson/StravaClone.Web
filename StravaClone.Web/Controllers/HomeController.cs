using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;
using System.Diagnostics;

namespace StravaClone.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IIPInfoService _IPInfoService;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(
            IIPInfoService IPInfoService,
            IUnitOfWork unitOfWork
            )
        {
            _IPInfoService = IPInfoService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var homeViewModel = new HomeViewModel();

            try
            {
                var info = await _IPInfoService.GetIPInfo();

                homeViewModel.City = info.City;
                homeViewModel.State = info.Region;

                if (homeViewModel.City != null)

                    homeViewModel.Clubs = await _unitOfWork.Club.GetClubsByCityAsync(homeViewModel.City);
                
                else
                
                    homeViewModel.Clubs = null;

                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                homeViewModel.Clubs = null;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
