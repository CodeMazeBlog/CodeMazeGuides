namespace PublishVsSendInMediatR.Services
{
    public class NotificationService : INotificationService
    {
        public Task SendNotificationAsync(int userId, string message)
        {
            return Task.CompletedTask;
        }
    }
}
