using MediatR;
using StravaClone.Web.Events;

namespace StravaClone.Web.Handlers
{
    public class CreateProfileEventHandler : INotificationHandler<UserSignUpEvent>
    {
        private readonly ILogger<CreateProfileEventHandler> _logger;

        public CreateProfileEventHandler(ILogger<CreateProfileEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(UserSignUpEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("User created: Create profile start for {UserId}", notification.UserId);

            await Task.Delay(1000, cancellationToken);

            _logger.LogInformation("User created: Create profile done for {UserId}", notification.UserId);
        }
    }
}
