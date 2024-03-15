using UniqueConstraintsInEFCore.Data;

namespace UniqueConstraintsInEFCore.Services
{
    public class InitializationService(IServiceScopeFactory scopeFactory)
        : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = scopeFactory.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<SolarSystemDbContext>();

            await context.Database.EnsureCreatedAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
    }
}
