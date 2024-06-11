namespace EfCoreInterceptors.Services;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> logger;

    public EmailService(ILogger<EmailService> logger)
    {
        this.logger = logger;
    }

    public async Task<bool> SendWelcomeEmailAsync(long userId, string userName, string userEmail)
    {
        logger.LogInformation("Sending welcome email to {email} with user id {userId} and user name {userName}",
            userEmail, userId, userName);

        await Task.Delay(TimeSpan.FromMilliseconds(300));

        return true;
    }
}