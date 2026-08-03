using RunningBackgroundTasks.Data;
using RunningBackgroundTasks.Services.Abstractions;

namespace RunningBackgroundTasks.Services.Periodic;

public class PeriodicHostedLifecycleService(
    IWorker worker,
    IPeriodicTimer timer,
    IServiceProvider serviceProvider) : IHostedLifecycleService
{
    public Task StartAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public async Task StartedAsync(CancellationToken cancellationToken)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        await using var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        while (!cancellationToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(cancellationToken))
        {
            await worker.ArchiveOldClientsAsync(context, cancellationToken);
        }
    }

    public Task StartingAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task StoppedAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task StoppingAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
