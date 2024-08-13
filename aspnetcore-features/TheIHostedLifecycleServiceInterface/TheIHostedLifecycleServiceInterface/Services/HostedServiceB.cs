namespace TheIHostedLifecycleServiceInterface.Services;

public class HostedServiceB : IHostedLifecycleService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceB)} start.");
        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceB)} started.");
        return Task.CompletedTask;
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceB)} starting.");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceB)} stop.");
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceB)} stopped.");
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Service {nameof(HostedServiceB)} stopping.");
        return Task.CompletedTask;
    }
}