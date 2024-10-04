using MediatR;
using StravaClone.Entities.Models;

namespace StravaClone.Web.Queries.Clubs
{
    public record GetAllClubsQuery : IRequest<IEnumerable<Club>>
    {
    }
}
