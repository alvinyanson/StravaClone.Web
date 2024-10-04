using Mapster;
using MediatR;
using StravaClone.Web.Commands.Races;
using StravaClone.DataService.Interfaces;
using StravaClone.Entities.Models;

namespace StravaClone.Web.Handlers.Races
{
    public class EditClubHandler : IRequestHandler<EditRaceRequest, ActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;

        public EditClubHandler(IUnitOfWork unitOfWork, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
        }

        public async Task<ActionResponse> Handle(EditRaceRequest request, CancellationToken cancellationToken)
        {
            var userClub = await _unitOfWork.Race.GetByIdAsyncNoTracking(request.Race.Id);

            if (userClub == null)
                return new ActionResponse { Success = false, ErrorMessage = "Race not found" };
            try
            {
                await _photoService.DeletePhotoAsync(userClub.Image);
            }
            catch (Exception ex)
            {
                return new ActionResponse { Success = false, ErrorMessage = "Could not delete photo" };
            }

            var photoResult = await _photoService.AddPhotoAsync(request.Race.Image);

            var race = request.Race.Adapt<Race>();
            race.Image = photoResult.Url.ToString();

            _unitOfWork.Race.Update(race);

            return new ActionResponse { Success = true };
        }
    }
}
