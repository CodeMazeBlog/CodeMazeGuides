using RunningBackgroundTasks.Data;
using RunningBackgroundTasks.Services.Abstractions;

namespace RunningBackgroundTasks.Services.One_off;

public class InitializationHostedLifecycleService(
    IWorker worker,
    IServiceProvider serviceProvider) : IHostedLifecycleService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        await using var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        await worker.SeedDatabaseAsync(context, cancellationToken);
    }

    public Task StartedAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task StartingAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task StoppedAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public Task StoppingAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
