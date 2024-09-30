using MediatR;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Queries
{
    public record GetAllClubsNearMeQuery : IRequest<HomeViewModel>
    {
    }
}
