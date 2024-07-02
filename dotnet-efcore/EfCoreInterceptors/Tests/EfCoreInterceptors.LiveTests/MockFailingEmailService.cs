using EfCoreInterceptors.Services;

namespace EfCoreInterceptors.LiveTests;

public class MockFailingEmailService : IEmailService
{
    public Task<bool> SendWelcomeEmailAsync(long userId, string userName, string email) => Task.FromResult(false);
}