namespace EfCoreInterceptors.Services;

public class EmailService(ILogger<EmailService> logger) : IEmailService
{
    public async Task<bool> SendWelcomeEmailAsync(long userId, string userName, string userEmail)
    {
        logger.LogInformation("Sending welcome email to {email} with user id {userId} and user name {userName}",
            userEmail, userId, userName);

        await Task.Delay(TimeSpan.FromMilliseconds(300));

        return true;
    }
}