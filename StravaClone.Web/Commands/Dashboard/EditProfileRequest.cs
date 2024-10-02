using MediatR;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Commands.Dashboard
{
    public class EditProfileRequest : IRequest<ActionResponse>
    {
        public EditUserDashboardViewModel Profile { get; }

        public EditProfileRequest(EditUserDashboardViewModel editUserDashboardViewModel)
        {
            Profile = editUserDashboardViewModel;
        }
    }
}
