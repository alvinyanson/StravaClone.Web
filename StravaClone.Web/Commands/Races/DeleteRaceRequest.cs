using MediatR;

namespace StravaClone.Web.Commands.Races
{
    public class DeleteRaceRequest : IRequest<bool>
    {
        public int Id { get; set; }
        
        public DeleteRaceRequest(int id)
        {
            Id = id;
        }
    }
}
