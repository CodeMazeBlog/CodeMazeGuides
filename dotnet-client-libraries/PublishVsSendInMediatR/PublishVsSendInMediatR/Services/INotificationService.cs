namespace PublishVsSendInMediatR.Services
{
    public interface INotificationService
    {
        Task SendNotificationAsync(int userId, string message);
    }
}
