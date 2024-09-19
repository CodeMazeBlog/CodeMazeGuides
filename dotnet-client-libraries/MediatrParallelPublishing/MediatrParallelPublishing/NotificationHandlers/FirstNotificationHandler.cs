using MediatR;

namespace MediatrParallelPublishing.NotificationHandlers;

public sealed class FirstNotificationHandler : INotificationHandler<Notification>
{
    public async Task Handle(Notification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("FirstNotificationHandler: Start");
        await Task.Delay(Random.Shared.Next(10, 50), cancellationToken);
        Console.WriteLine($"FirstNotificationHandler: {notification.Message}");
    }
}