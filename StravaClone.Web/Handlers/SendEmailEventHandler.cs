using MediatR;
using Microsoft.Extensions.Logging;
using StravaClone.Web.Events;

namespace StravaClone.Web.Handlers
{
    public class SendEmailEventHandler : INotificationHandler<UserSignUpEvent>
    {
        private readonly ILogger<SendEmailEventHandler> _logger;

        public SendEmailEventHandler(ILogger<SendEmailEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(UserSignUpEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("User created: Send mail start for {UserId}", notification.UserId);

            await Task.Delay(1000, cancellationToken);

            _logger.LogInformation("User created: Send mail done for {UserId}", notification.UserId);
        }
    }
}
