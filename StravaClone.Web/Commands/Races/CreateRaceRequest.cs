using MediatR;
using StravaClone.Entities.Models;
using StravaClone.Entities.ViewModels;

namespace StravaClone.Web.Commands.Races
{
    public class CreateRaceRequest : IRequest<ActionResponse>
    {
        public CreateRaceViewModel Race { get; }
        
        public CreateRaceRequest(CreateRaceViewModel createRaceViewModel)
        {
            Race = createRaceViewModel;
        }
    }
}
