namespace ChangeServiceLifetimeOfAlreadyRegisteredService.Services;

public class LocalDevelopmentService : IService
{
    public LocalDevelopmentService(ILogger<LocalDevelopmentService> logger)
    {
        logger.LogInformation("Hello from LocalDevelopmentService");
    }
}