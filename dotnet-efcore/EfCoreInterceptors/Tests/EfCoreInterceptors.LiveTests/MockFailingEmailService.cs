namespace EfCoreInterceptors.LiveTests;

using EfCoreInterceptors.Services;

public class MockFailingEmailService : IEmailService
{
    public Task<bool> SendWelcomeEmailAsync(long userId, string userName, string email) => Task.FromResult(false);
}