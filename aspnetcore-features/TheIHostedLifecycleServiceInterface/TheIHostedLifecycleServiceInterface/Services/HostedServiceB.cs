namespace TheIHostedLifecycleServiceInterface.Services;

public class HostedServiceB(ILogger<HostedServiceB> logger) : IHostedLifecycleService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceB)} start.");

        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceB)} started.");

        return Task.CompletedTask;
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceB)} starting.");

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceB)} stop.");

        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceB)} stopped.");

        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceB)} stopping.");

        return Task.CompletedTask;
    }
}