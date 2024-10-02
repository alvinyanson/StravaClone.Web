using MediatR;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.Queries.Races;

namespace StravaClone.Web.Handlers.Races
{
    public class GetRaceDetailHandler : IRequestHandler<GetRaceDetailQuery, Race>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRaceDetailHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Race> Handle(GetRaceDetailQuery request, CancellationToken cancellationToken)
        {
            var race = await _unitOfWork.Race.GetByIdAsync(request.Id);

            return race;
        }
    }
}
