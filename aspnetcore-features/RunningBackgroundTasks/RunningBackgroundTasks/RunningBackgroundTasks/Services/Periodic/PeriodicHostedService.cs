using RunningBackgroundTasks.Data;
using RunningBackgroundTasks.Services.Abstractions;

namespace RunningBackgroundTasks.Services.Periodic;

public class PeriodicHostedService(
    IWorker worker,
    IPeriodicTimer timer,
    IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
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

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
