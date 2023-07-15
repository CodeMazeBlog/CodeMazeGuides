namespace MockingWithNSubstitute
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailService _emailService;

        public NotificationService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void NotifyUser(User user, string message)
        {
            if (user is null ||
                user.Email is null ||
                string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            _emailService.SendEmail(user.Email, "Notification from CodeMaze", message);
        }
    }
}
