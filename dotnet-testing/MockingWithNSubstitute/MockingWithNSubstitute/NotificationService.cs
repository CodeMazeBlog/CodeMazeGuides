namespace MockingWithNSubstitute;

public class NotificationService : INotificationService
{
    private readonly IEmailService _emailService;

    public NotificationService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public bool NotifyUser(User user, string message)
    {
        if (!_emailService.IsValidEmail(user.Email) ||
            string.IsNullOrWhiteSpace(message))
        {
            return false;
        }

        try
        {
            var sentSuccessfully = _emailService
            .SendEmail(user.Email, "Notification from CodeMaze", message);

            return sentSuccessfully;
        }
        catch
        {
            throw;
        }
    }
}
