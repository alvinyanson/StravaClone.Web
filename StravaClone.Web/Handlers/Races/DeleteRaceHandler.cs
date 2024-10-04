using MediatR;
using StravaClone.Web.Commands.Races;
using StravaClone.DataService.Interfaces;

namespace StravaClone.Web.Handlers.Races
{
    public class DeleteRaceHandler : IRequestHandler<DeleteRaceRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRaceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteRaceRequest request, CancellationToken cancellationToken)
        {
            var raceDetail = await _unitOfWork.Race.GetByIdAsync(request.Id);

            if (raceDetail == null)
                return false;

            _unitOfWork.Race.Delete(raceDetail);
            return true;
        }
    }
}
