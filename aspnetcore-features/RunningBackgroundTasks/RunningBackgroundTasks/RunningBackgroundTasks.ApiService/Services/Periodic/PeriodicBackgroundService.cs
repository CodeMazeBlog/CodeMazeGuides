using RunningBackgroundTasks.ApiService.Services.Abstractions;
using RunningBackgroundTasks.Domain;

namespace RunningBackgroundTasks.ApiService.Services.Periodic;

public class PeriodicBackgroundService(
    IWorker worker,
    IPeriodicTimer timer,
    IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        using var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        while (!stoppingToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(stoppingToken))
        {
            await worker.ArchiveOldClientsAsync(context, stoppingToken);
        }
    }
}
