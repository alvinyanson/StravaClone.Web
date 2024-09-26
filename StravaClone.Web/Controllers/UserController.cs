using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using StravaClone.Web.Interfaces;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [OutputCache(PolicyName = "Expire20")]
        public async Task<IActionResult> Index()
        {
            var users = await _unitOfWork.User.GetAllUsers();

            List<UserViewModel> result = new List<UserViewModel>();

            foreach (var user in users)
            {
                var userViewModel = user.Adapt<UserViewModel>();

                result.Add(userViewModel);
            }

            return View(result);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = await _unitOfWork.User.GetUserById(id);

            var userDetailViewModel = user.Adapt<UserDetailViewModel>();

            return View(userDetailViewModel);
        }
    }
}
