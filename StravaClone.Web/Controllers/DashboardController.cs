﻿using CloudinaryDotNet.Actions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        public DashboardController(
            IDashboardRepository dashboardRepository,
            IHttpContextAccessor httpContextAccessor,
            IPhotoService photoService)
        {
            _dashboardRepository = dashboardRepository;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }

        private void MapUserEdit(AppUser user, EditUserDashboardViewModel editVM, ImageUploadResult photoResult)
        {
            user.Id = editVM.Id;
            user.Pace = editVM.Pace;
            user.MileAge = editVM.MileAge;
            user.ProfileImageUrl = photoResult.Url.ToString();
            user.City = editVM.City;
            user.State = editVM.State;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userRaces = await _dashboardRepository.GetAllUserRaces();
            var userClubs = await _dashboardRepository.GetAllUserClubs();

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

            var user = await _dashboardRepository.GetUserById(userId);

            if (user == null) return View("Error");

            var editUserViewModel = new EditUserDashboardViewModel()
            {
                Id = userId,
                Pace = user.Pace,
                MileAge = user.MileAge,
                ProfileImageUrl = user.ProfileImageUrl,
                City = user.City,
                State = user.State,
            };

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

            var user = await _dashboardRepository.GetByIdNoTracking(request.Id);
            
            var photoResult = await _photoService.AddPhotoAsync(request.Image);

            if (user.ProfileImageUrl == "" || user.ProfileImageUrl == null)
            {
                MapUserEdit(user, request, photoResult);
                _dashboardRepository.Update(user);

                return RedirectToAction(nameof(Index));

                //// Optimistic concurrency  - "Tracking error"
                //// Use No Tracking
                //var userTracking = new AppUser()
                //{

                //};
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

                MapUserEdit(user, request, photoResult);
                
                _dashboardRepository.Update(user);

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
