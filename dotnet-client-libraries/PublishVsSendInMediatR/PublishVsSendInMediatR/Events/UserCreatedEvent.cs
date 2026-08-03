using MediatR;

namespace PublishVsSendInMediatR.Events
{
    public class UserCreatedEvent : INotification
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
