using RunningBackgroundTasks.ApiService.Services.Abstractions;
using RunningBackgroundTasks.Domain;

namespace RunningBackgroundTasks.ApiService.Services.One_off;

public class InitializationBackgroundService(
    IWorker worker,
    IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        await using var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        await worker.SeedDatabaseAsync(context, stoppingToken);
    }
}
