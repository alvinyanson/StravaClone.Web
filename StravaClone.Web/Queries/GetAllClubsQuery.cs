using MediatR;
using StravaClone.Web.Models;

namespace StravaClone.Web.Queries
{
    public class GetAllClubsQuery : IRequest<IEnumerable<Club>>
    {
    }
}
