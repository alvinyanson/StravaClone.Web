using MediatR;
using StravaClone.Entities.ViewModels;

namespace StravaClone.Web.Queries.Dashboard
{
    public class GetProfileQuery : IRequest<EditUserDashboardViewModel>
    {
    }
}
