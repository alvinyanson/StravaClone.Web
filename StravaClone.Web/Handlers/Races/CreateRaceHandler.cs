using Mapster;
using MediatR;
using StravaClone.Web.Commands.Races;
using StravaClone.DataService.Interfaces;
using StravaClone.Entities.Models;

namespace StravaClone.Web.Handlers.Races
{
    public class CreateRaceHandler : IRequestHandler<CreateRaceRequest, ActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;

        public CreateRaceHandler(IUnitOfWork unitOfWork, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
        }

        public async Task<ActionResponse> Handle(CreateRaceRequest request, CancellationToken cancellationToken)
        {
            var result = await _photoService.AddPhotoAsync(request.Race.Image);

            var race = request.Race.Adapt<Race>();
            race.Image = result.Url.ToString();

            _unitOfWork.Race.Add(race);

            return new ActionResponse() { Success = true };
        }
    }
}
