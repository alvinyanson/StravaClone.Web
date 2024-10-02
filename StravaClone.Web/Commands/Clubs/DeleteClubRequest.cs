using MediatR;

namespace StravaClone.Web.Commands.Club
{
    public class DeleteClubRequest: IRequest<bool>
    {
        public int Id { get; }

        public DeleteClubRequest(int id)
        {
            Id = id;
        }
    }
}
