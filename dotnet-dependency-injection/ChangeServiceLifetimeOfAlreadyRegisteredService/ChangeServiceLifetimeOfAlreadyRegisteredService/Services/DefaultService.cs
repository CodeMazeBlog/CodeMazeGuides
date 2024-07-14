namespace ChangeServiceLifetimeOfAlreadyRegisteredService.Services;

public class DefaultService : IService
{
    public DefaultService(ILogger<DefaultService> logger)
    {
        logger.LogInformation("Hello from DefaultService");
    }
}