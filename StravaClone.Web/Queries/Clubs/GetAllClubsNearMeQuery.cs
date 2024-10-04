using MediatR;
using StravaClone.Entities.ViewModels;

namespace StravaClone.Web.Queries.Clubs
{
    public record GetAllClubsNearMeQuery : IRequest<HomeViewModel>
    {
    }
}
