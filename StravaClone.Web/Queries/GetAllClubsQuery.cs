using MediatR;
using StravaClone.Web.Models;

namespace StravaClone.Web.Queries
{
    public record GetAllClubsQuery : IRequest<IEnumerable<Club>>
    {
    }
}
