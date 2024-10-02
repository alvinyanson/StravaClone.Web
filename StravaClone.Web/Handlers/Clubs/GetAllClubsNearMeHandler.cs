using MediatR;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Queries.Clubs;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Handlers.Clubs
{
    public class GetAllClubsNearMeHandler : IRequestHandler<GetAllClubsNearMeQuery, HomeViewModel>
    {

        private readonly IIPInfoService _IPInfoService;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClubsNearMeHandler(
            IIPInfoService IPInfoService,
            IUnitOfWork unitOfWork)
        {
            _IPInfoService = IPInfoService;
            _unitOfWork = unitOfWork;
        }

        public async Task<HomeViewModel> Handle(GetAllClubsNearMeQuery request, CancellationToken cancellationToken)
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

                return homeViewModel;
            }
            catch (Exception ex)
            {
                homeViewModel.Clubs = null;

                return homeViewModel;
            }
        }
    }
}
