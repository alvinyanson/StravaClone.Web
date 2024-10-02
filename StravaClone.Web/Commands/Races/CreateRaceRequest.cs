using MediatR;
using StravaClone.Web.Models;
using StravaClone.Web.ViewModels;

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
