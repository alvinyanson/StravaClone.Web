using MediatR;
using StravaClone.Web.Models;

namespace StravaClone.Web.Queries.Clubs
{
    public class GetClubDetailQuery : IRequest<Club>
    {
        public int Id { get; }

        public GetClubDetailQuery(int id)
        {
            Id = id;
        }
    }
}
