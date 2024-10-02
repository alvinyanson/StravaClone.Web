using Mapster;
using MediatR;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Queries.Dashboard;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Handlers.Dashboard
{
    public class GetProfileHandler : IRequestHandler<GetProfileQuery, EditUserDashboardViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetProfileHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<EditUserDashboardViewModel> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();

            var user = await _unitOfWork.Dashboard.GetUserById(userId);

            var editUserViewModel = user.Adapt<EditUserDashboardViewModel>();

            return editUserViewModel;
        }
    }
}
