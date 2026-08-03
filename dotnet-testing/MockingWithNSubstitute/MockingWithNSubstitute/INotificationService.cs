namespace MockingWithNSubstitute;

public interface INotificationService
{
    bool NotifyUser(User user, string message);
}
