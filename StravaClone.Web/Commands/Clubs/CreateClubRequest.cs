using MediatR;
using StravaClone.Entities.ViewModels;

namespace StravaClone.Web.Commands.Club
{
    public class CreateClubRequest : IRequest<bool>
    {
        public CreateClubViewModel Club { get; }

        public CreateClubRequest(CreateClubViewModel createClubViewModel)
        {
            Club = createClubViewModel;
        }
    }
}
