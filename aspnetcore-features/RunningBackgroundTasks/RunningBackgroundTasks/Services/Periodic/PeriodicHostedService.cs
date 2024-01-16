using Microsoft.EntityFrameworkCore;
using RunningBackgroundTasks.Data;

namespace RunningBackgroundTasks.Services.Periodic;

public class PeriodicHostedService(
    TimeProvider timeProvider,
    IServiceProvider serviceProvider) : IHostedService
{
    private readonly TimeSpan _period = TimeSpan.FromSeconds(24);

    public async Task StartAsync(CancellationToken cancellationToken)
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

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
