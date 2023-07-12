using Microsoft.Extensions.DependencyInjection;

namespace MessagingLibrary;

public class Notifier
{
    private readonly INotification? _notification;
    private readonly IEnumerable<INotification>? _notifications;
    public string? NotificationHandler { get; }

    public Notifier(string notificationType)
    {
        if (DependenciesRegistration.DependenciesProvider != null)
            _notifications = DependenciesRegistration.DependenciesProvider.GetServices<INotification>();

        if (_notifications != null)
            _notification = notificationType switch
            {
                "sms" => _notifications.FirstOrDefault(x => x.GetType() == typeof(Sms)),
                "email" => _notifications.FirstOrDefault(x => x.GetType() == typeof(Email)),
                _ => throw new ArgumentException("Invalid notification type")
            };
        NotificationHandler = _notification?.SendNotification();
    }
}