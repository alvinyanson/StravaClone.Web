using MediatR;
using StravaClone.Web.Commands.Club;
using StravaClone.DataService.Interfaces;

namespace StravaClone.Web.Handlers.Clubs
{
    public class DeleteClubHandler : IRequestHandler<DeleteClubRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClubHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteClubRequest request, CancellationToken cancellationToken)
        {
            var clubDetail = await _unitOfWork.Club.GetByIdAsync(request.Id);

            if (clubDetail == null)
                return false;

            _unitOfWork.Club.Delete(clubDetail);

            return true;
        }
    }
}
