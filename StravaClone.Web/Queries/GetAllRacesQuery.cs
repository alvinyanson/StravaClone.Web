using MediatR;
using StravaClone.Web.Models;

namespace StravaClone.Web.Queries
{
    public record GetAllRacesQuery : IRequest<IEnumerable<Race>>
    {
    }
}
