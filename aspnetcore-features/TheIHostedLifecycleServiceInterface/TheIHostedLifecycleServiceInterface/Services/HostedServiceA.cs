﻿namespace TheIHostedLifecycleServiceInterface.Services;

public class HostedServiceA(ILogger<HostedServiceA> logger) : IHostedLifecycleService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceA)} start.");

        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceA)} started.");

        return Task.CompletedTask;
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceA)} starting.");

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceA)} stop.");

        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceA)} stopped.");

        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Service {nameof(HostedServiceA)} stopping.");

        return Task.CompletedTask;
    }
}