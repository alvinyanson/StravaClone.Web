using MediatR;
using StravaClone.Web.Models;

namespace StravaClone.Web.Queries.Clubs
{
    public record GetAllClubsQuery : IRequest<IEnumerable<Club>>
    {
    }
}
