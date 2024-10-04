using MediatR;
using StravaClone.DataService.Interfaces;
using StravaClone.Entities.Models;
using StravaClone.Web.Queries.Clubs;

namespace StravaClone.Web.Handlers.Clubs
{
    public class GetAllClubsHandler : IRequestHandler<GetAllClubsQuery, IEnumerable<Club>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClubsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Club>> Handle(GetAllClubsQuery request, CancellationToken cancellationToken)
        {
            var clubs = await _unitOfWork.Club.GetAllAsync();

            return clubs;
        }
    }
}
