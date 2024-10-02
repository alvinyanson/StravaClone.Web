using MediatR;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Queries.Clubs
{
    public record GetAllClubsNearMeQuery : IRequest<HomeViewModel>
    {
    }
}
