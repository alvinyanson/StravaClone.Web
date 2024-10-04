using MediatR;
using StravaClone.Entities.Models;

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
