using RunningBackgroundTasks.Data;
using RunningBackgroundTasks.Services.Abstractions;

namespace RunningBackgroundTasks.Services.One_off;

public class InitializationHostedService(
    IWorker worker,
    IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        await using var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        await worker.SeedDatabaseAsync(context, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
