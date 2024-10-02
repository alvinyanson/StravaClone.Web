using MediatR;
using StravaClone.Web.Models;

namespace StravaClone.Web.Queries.Races
{
    public class GetRaceDetailQuery : IRequest<Race>
    {
        public int Id { get; set; }

        public GetRaceDetailQuery(int id)
        {
            Id = id;
        }
    }
}
