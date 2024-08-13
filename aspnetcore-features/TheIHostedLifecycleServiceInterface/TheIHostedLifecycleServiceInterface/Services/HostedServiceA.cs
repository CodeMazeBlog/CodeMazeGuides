namespace TheIHostedLifecycleServiceInterface.Services;

public class HostedServiceA : IHostedLifecycleService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceA)} start.");
        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceA)} started.");
        return Task.CompletedTask;
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceA)} starting.");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceA)} stop.");
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceA)} stopped.");
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceA)} stopping.");
        return Task.CompletedTask;
    }
}

