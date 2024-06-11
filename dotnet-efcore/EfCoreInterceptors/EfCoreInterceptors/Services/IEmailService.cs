namespace EfCoreInterceptors.Services;

public interface IEmailService
{
    Task<bool> SendWelcomeEmailAsync(long userId, string userName, string userEmail);
}