using MediatR;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Commands.Club
{
    public class EditClubRequest : IRequest<ActionResponse>
    {
        public EditClubViewModel Club { get; }

        public EditClubRequest(EditClubViewModel editClubViewModel)
        {
            Club = editClubViewModel;
        }
    }
}
