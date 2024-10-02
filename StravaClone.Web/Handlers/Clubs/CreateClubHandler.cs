using Mapster;
using MediatR;
using StravaClone.Web.Commands.Club;
using StravaClone.Web.Interfaces;
using StravaClone.Web.Models;

namespace StravaClone.Web.Handlers.Clubs
{
    public class CreateClubHandler : IRequestHandler<CreateClubRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;

        public CreateClubHandler(IUnitOfWork unitOfWork, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
        }

        public async Task<bool> Handle(CreateClubRequest request, CancellationToken cancellationToken)
        {
            var result = await _photoService.AddPhotoAsync(request.Club.Image);

            var club = request.Club.Adapt<Club>();
            club.Image = result.Url.ToString();

            _unitOfWork.Club.Add(club);

            return true;
        }
    }
}
