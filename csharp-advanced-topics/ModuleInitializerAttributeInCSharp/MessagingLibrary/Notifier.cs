using Microsoft.Extensions.DependencyInjection;

namespace MessagingLibrary;

public class Notifier
{
    private readonly INotification? _notification;
    private readonly IEnumerable<INotification>? _notificationServiceLocator;
    
    public string NotificationResult { get; }

    public Notifier(string notificationType)
    {
        _notificationServiceLocator = DependenciesRegistration.DependenciesProvider.GetServices<INotification>();

        if (_notificationServiceLocator is not null)
            _notification = notificationType switch
            {
                "sms" => _notificationServiceLocator.OfType<Sms>().FirstOrDefault(),
                "email" => _notificationServiceLocator.OfType<Email>().FirstOrDefault(),
                _ => throw new ArgumentException("Invalid notification type")
            };
        NotificationResult = _notification?.SendNotification()!;
    }
}