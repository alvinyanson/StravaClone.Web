using MediatR;
using StravaClone.Web.ViewModels;

namespace StravaClone.Web.Queries.Dashboard
{
    public class GetProfileQuery : IRequest<EditUserDashboardViewModel>
    {
    }
}
