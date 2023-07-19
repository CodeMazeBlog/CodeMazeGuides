using Microsoft.Extensions.DependencyInjection;

namespace MessagingLibrary;

public class Notifier
{
    private readonly INotification? _notification;
    private readonly IEnumerable<INotification>? _notificationServiceLocator;
    public string NotificationHandler { get; }

    public Notifier(string notificationType)
    {
        if (DependenciesRegistration.DependenciesProvider != null)
            _notificationServiceLocator = DependenciesRegistration.DependenciesProvider.GetServices<INotification>();

        if (_notificationServiceLocator != null)
            _notification = notificationType switch
            {
                "sms" => _notificationServiceLocator.FirstOrDefault(x => x.GetType() == typeof(Sms)),
                "email" => _notificationServiceLocator.FirstOrDefault(x => x.GetType() == typeof(Email)),
                _ => throw new ArgumentException("Invalid notification type")
            };
        NotificationHandler = _notification?.SendNotification();
    }
}