using MediatR;
using StravaClone.Web.Models;

namespace StravaClone.Web.Queries.Races
{
    public record GetAllRacesQuery : IRequest<IEnumerable<Race>>
    {
    }
}
