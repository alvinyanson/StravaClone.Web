using MediatR;

namespace StravaClone.Web.Events
{
    public record UserSignUpEvent(string UserId) : INotification
    {
    }
}
