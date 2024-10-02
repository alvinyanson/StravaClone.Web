using MediatR;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Commands.Races
{
    public class EditRaceRequest : IRequest<ActionResponse>
    {
        public EditRaceViewModel Race { get; }
        
        public EditRaceRequest(EditRaceViewModel editRaceViewModel)
        {
            Race = editRaceViewModel;
        }
    }
}
