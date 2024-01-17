using RunningBackgroundTasks.ApiService.Services.Abstractions;
using RunningBackgroundTasks.Domain;

namespace RunningBackgroundTasks.ApiService.Services.Periodic;

public class PeriodicHostedService(
    IWorker worker,
    IPeriodicTimer timer,
    IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        using var context = scope.ServiceProvider
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
