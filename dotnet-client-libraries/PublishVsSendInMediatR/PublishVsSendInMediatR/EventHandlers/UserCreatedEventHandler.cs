using MediatR;
using PublishVsSendInMediatR.Events;
using PublishVsSendInMediatR.Repositories;
using PublishVsSendInMediatR.Services;

namespace PublishVsSendInMediatR.EventHandlers
{
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationService _notificationService;

        public UserCreatedEventHandler(IUserRepository userRepository, INotificationService notificationService)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            var admin = await _userRepository.GetAdminUserAsync();
            string message = $"New user created: ID: {notification.UserId}, UserName: {notification.UserName}";

            await _notificationService.SendNotificationAsync(admin.UserId, message);
        }
    }
}
