using Mapster;
using MediatR;
using StravaClone.Web.Commands.Club;
using StravaClone.DataService.Interfaces;
using StravaClone.Entities.Models;

namespace StravaClone.Web.Handlers.Clubs
{
    public class EditClubHandler : IRequestHandler<EditClubRequest, ActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;

        public EditClubHandler(IUnitOfWork unitOfWork, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
        }

        public async Task<ActionResponse> Handle(EditClubRequest request, CancellationToken cancellationToken)
        {
            var userClub = await _unitOfWork.Club.GetByIdAsyncNoTracking(request.Club.Id);

            if (userClub == null)
                return new ActionResponse() { Success = false, ErrorMessage = "Club does not exist"};

            try
            {
                await _photoService.DeletePhotoAsync(userClub.Image);
            }
            catch (Exception ex)
            {
                return new ActionResponse() { Success = false, ErrorMessage = "Could not delete photo" };
            }

            var photoResult = await _photoService.AddPhotoAsync(request.Club.Image);

            var club = request.Club.Adapt<Club>();
            club.Image = photoResult.Url.ToString();

            _unitOfWork.Club.Update(club);

            return new ActionResponse() { Success = true };
        }
    }
}
