using Mapster;
using Microsoft.AspNetCore.Mvc;
using StravaClone.Web.Interfaces;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();

            List<UserViewModel> result = new List<UserViewModel>();

            foreach (var user in users)
            {
                var userViewModel = user.Adapt<UserViewModel>();

                result.Add(userViewModel);
            }

            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);

            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                Username = user.UserName,
                Pace = user.Pace,
                MileAge = user.MileAge,
                ProfileImageUrl = user.ProfileImageUrl,
            };

            return View(userDetailViewModel);
        }
    }
}
