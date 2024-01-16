namespace RunningBackgroundTasks.Tests.One_off;

public class InitializationHostedServiceTests : IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder().Build();

    [Fact]
    public async Task WhenStartAsyncIsInvoked_MigrationsShouldBeApplied()
    {
        // Arrange
        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_msSqlContainer.GetConnectionString()))
            .BuildServiceProvider();

        var backgroundService = new InitializationHostedService(serviceProvider);

        // Act
        await backgroundService.StartAsync(default);

        // Assert
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // Ensure migrations are applied
        var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
        pendingMigrations.Should().BeEmpty();
    }

    public Task InitializeAsync()
        => _msSqlContainer.StartAsync();

    public Task DisposeAsync()
        => _msSqlContainer.DisposeAsync().AsTask();
}
