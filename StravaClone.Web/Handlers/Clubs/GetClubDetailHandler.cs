using MediatR;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.Queries.Clubs;

namespace StravaClone.Web.Handlers.Clubs
{
    public class GetClubDetailHandler : IRequestHandler<GetClubDetailQuery, Club>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClubDetailHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Club> Handle(GetClubDetailQuery request, CancellationToken cancellationToken)
        {
            var club = await _unitOfWork.Club.GetByIdAsync(request.Id);

            return club;
        }
    }
}
