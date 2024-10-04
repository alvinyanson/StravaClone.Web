using MediatR;
using StravaClone.Entities.Models;
using StravaClone.Entities.ViewModels;

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
