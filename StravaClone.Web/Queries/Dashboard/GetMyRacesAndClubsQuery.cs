using MediatR;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Queries.Dashboard
{
    public class GetMyRacesAndClubsQuery : IRequest<DashboardViewModel>
    {
    }
}
