using MediatR;
using StravaClone.Web.Commands.Dashboard;
using StravaClone.DataService.Interfaces;
using StravaClone.Entities.Models;

namespace StravaClone.Web.Handlers.Dashboard
{
    public class EditProfileHandler : IRequestHandler<EditProfileRequest, ActionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;

        public EditProfileHandler(IUnitOfWork unitOfWork, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
        }

        public async Task<ActionResponse> Handle(EditProfileRequest request, CancellationToken cancellationToken)
        {

            var user = await _unitOfWork.Dashboard.GetByIdNoTracking(request.Profile.Id);

            var photoResult = await _photoService.AddPhotoAsync(request.Profile.Image);

            if (user.ProfileImageUrl == "" || user.ProfileImageUrl == null)
            {
                user.Pace = request.Profile.Pace;
                user.MileAge = request.Profile.MileAge;
                user.City = request.Profile.City;
                user.State = request.Profile.State;
                user.ProfileImageUrl = photoResult.Url.ToString();


                _unitOfWork.Dashboard.Update(user);

                return new ActionResponse { Success = true };

            }
            else
            {
                try
                {
                    await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }
                catch (Exception ex)
                {
                    return new ActionResponse { Success = false, ErrorMessage = "Could not delete photo" };
                }

                user.Pace = request.Profile.Pace;
                user.MileAge = request.Profile.MileAge;
                user.City = request.Profile.City;
                user.State = request.Profile.State;
                user.ProfileImageUrl = photoResult.Url.ToString();

                _unitOfWork.Dashboard.Update(user);

                return new ActionResponse { Success = true };
            }

        }
    }
}
