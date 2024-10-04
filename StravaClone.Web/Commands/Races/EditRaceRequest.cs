using MediatR;
using StravaClone.Entities.Models;
using StravaClone.Entities.ViewModels;

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
