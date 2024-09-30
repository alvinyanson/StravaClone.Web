using MediatR;
using StravaClone.Web.Models;

namespace StravaClone.Web.Queries
{
    public class GetAllRacesQuery : IRequest<IEnumerable<Race>>
    {
    }
}
