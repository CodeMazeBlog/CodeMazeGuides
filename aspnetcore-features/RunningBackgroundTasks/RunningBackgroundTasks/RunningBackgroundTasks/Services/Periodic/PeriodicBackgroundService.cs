using RunningBackgroundTasks.Data;
using RunningBackgroundTasks.Services.Abstractions;

namespace RunningBackgroundTasks.Services.Periodic;

public class PeriodicBackgroundService(
    IWorker worker,
    IPeriodicTimer timer,
    IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        await using var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        while (!stoppingToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(stoppingToken))
        {
            await worker.ArchiveOldClientsAsync(context, stoppingToken);
        }
    }
}
