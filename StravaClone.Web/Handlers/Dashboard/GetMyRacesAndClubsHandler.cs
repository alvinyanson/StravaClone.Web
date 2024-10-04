using MediatR;
using StravaClone.DataService.Interfaces;
using StravaClone.Web.Queries.Dashboard;
using StravaClone.Entities.ViewModels;

namespace StravaClone.Web.Handlers.Dashboard
{
    public class GetMyRacesAndClubsHandler : IRequestHandler<GetMyRacesAndClubsQuery, DashboardViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetMyRacesAndClubsHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<DashboardViewModel> Handle(GetMyRacesAndClubsQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();

            var userRaces = await _unitOfWork.Dashboard.GetAllUserRaces(currentUser.ToString());
            var userClubs = await _unitOfWork.Dashboard.GetAllUserClubs(currentUser.ToString());

            var dashboardVM = new DashboardViewModel
            {
                Races = userRaces,
                Clubs = userClubs,
            };

            return dashboardVM;
        }
    }
}
