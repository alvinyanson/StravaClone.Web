using MediatR;
using StravaClone.DataService.Interfaces;
using StravaClone.Entities.Models;
using StravaClone.Web.Queries.Races;

namespace StravaClone.Web.Handlers.Races
{
    public class GetAllRacesHandler : IRequestHandler<GetAllRacesQuery, IEnumerable<Race>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllRacesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Race>> Handle(GetAllRacesQuery request, CancellationToken cancellationToken)
        {
            var races = await _unitOfWork.Race.GetAllAsync();

            return races;
        }
    }
}
