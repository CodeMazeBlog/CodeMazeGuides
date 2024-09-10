using MediatR;

namespace MediatrParallelPublishing.NotificationHandlers;

public sealed class SecondNotificationHandler : INotificationHandler<Notification>
{
    public async Task Handle(Notification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("SecondNotificationHandler: Start");
        await Task.Delay(Random.Shared.Next(1000, 5000), cancellationToken);
        Console.WriteLine($"SecondNotificationHandler: {notification.Message}");
    }
}