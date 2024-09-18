using MediatR;

namespace MediatrParallelPublishing.NotificationHandlers;

public sealed class SecondNotificationHandler : INotificationHandler<Notification>
{
    public async Task Handle(Notification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("SecondNotificationHandler: Start");
        await Task.Delay(Random.Shared.Next(10, 50), cancellationToken);
        Console.WriteLine($"SecondNotificationHandler: {notification.Message}");
    }
}