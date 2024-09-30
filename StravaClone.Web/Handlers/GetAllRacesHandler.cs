using MediatR;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;
using StravaClone.Web.Queries;

namespace StravaClone.Web.Handlers
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
