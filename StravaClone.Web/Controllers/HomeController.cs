using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Newtonsoft.Json;
using StravaClone.Web.Helpers;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace StravaClone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIPInfoService _iPInfoService;

        public HomeController(
            ILogger<HomeController> logger,
            IUnitOfWork unitOfWork,
            IIPInfoService iPInfoService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _iPInfoService = iPInfoService;
        }

        public async Task<IActionResult> Index()
        {
            var homeViewModel = new HomeViewModel();

            try
            {
                var info = await _iPInfoService.GetIPInfo();

                homeViewModel.City = info.City;
                homeViewModel.State = info.Region;

                if (homeViewModel.City != null)
                {
                    homeViewModel.Clubs = await _unitOfWork.Club.GetClubsByCityAsync(homeViewModel.City);
                }
                else
                {
                    homeViewModel.Clubs = null;
                }

                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                homeViewModel.Clubs = null;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
