using Microsoft.EntityFrameworkCore;
using RunningBackgroundTasks.Data;

namespace RunningBackgroundTasks.Services.Periodic;

public class PeriodicHostedLifecycleService(
    TimeProvider timeProvider,
    IServiceProvider serviceProvider) : IHostedLifecycleService
{
    private readonly TimeSpan _period = TimeSpan.FromHours(24);

    public Task StartAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;

    public async Task StartedAsync(CancellationToken cancellationToken)
    {
        using var timer = new PeriodicTimer(_period, timeProvider);

        using IServiceScope scope = serviceProvider.CreateScope();

        using var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        while (!cancellationToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(cancellationToken))
        {
            var cutoff = timeProvider.GetUtcNow().AddMonths(-6);

            await context.Clients
                .Where(x => x.LastOrderDate <= cutoff)
                .ExecuteUpdateAsync(setters =>
                    setters.SetProperty(b => b.IsActive, false),
                    cancellationToken: cancellationToken);
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
