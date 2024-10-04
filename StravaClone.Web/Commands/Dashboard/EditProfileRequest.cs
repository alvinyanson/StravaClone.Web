using MediatR;
using StravaClone.Entities.Models;
using StravaClone.Entities.ViewModels;

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
