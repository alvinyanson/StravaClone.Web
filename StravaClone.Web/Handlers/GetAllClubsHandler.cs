using MediatR;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.Queries;
using StravaClone.Web.Repository;

namespace StravaClone.Web.Handlers
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
