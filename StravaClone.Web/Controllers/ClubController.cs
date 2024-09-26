﻿using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Controllers
{
    public class ClubController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClubController(
            IUnitOfWork unitOfWork,
            IPhotoService photoService,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        [OutputCache(PolicyName = "Expire20")]
        public async Task<IActionResult> Index()
        {
            var clubs = await _unitOfWork.Club.GetAllAsync();

            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var club = await _unitOfWork.Club.GetByIdAsync(id);

            return View(club);
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
                var result = await _photoService.AddPhotoAsync(request.Image);

                var club = request.Adapt<Club>();
                club.Image = result.Url.ToString();

                _unitOfWork.Club.Add(club);

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
            var club = await _unitOfWork.Club.GetByIdAsync(id);

            if (club == null) return View("Error");

            var clubVM = club.Adapt<EditClubViewModel>();

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

            var userClub = await _unitOfWork.Club.GetByIdAsyncNoTracking(id);

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

            var club = request.Adapt<Club>();
            club.Image = photoResult.Url.ToString();

            _unitOfWork.Club.Update(club);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var clubDetail = await _unitOfWork.Club.GetByIdAsync(id);

            if (clubDetail == null) return View("Error");

            return View(clubDetail);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var clubDetail = await _unitOfWork.Club.GetByIdAsync(id);

            if (clubDetail == null) return View("Error");

            _unitOfWork.Club.Delete(clubDetail);

            return RedirectToAction(nameof(Index));
        }

    }
}
