namespace RunningBackgroundTasks.ApiService.Tests;

public class WorkerTests : IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder().Build();

    [Fact]
    public async Task WhenArchiveOldClientsAsyncIsInvoked_ThenExpectedNumberOfClientsAreArchived()
    {
        // Arrange
        var context = InitializeDatabase();
        await context.Database.EnsureCreatedAsync();

        var fakeTimeProvider = new FakeTimeProvider();
        fakeTimeProvider.SetUtcNow(DateTimeOffset.UtcNow);

        await context.Clients.AddAsync(new Client
        {
            Id = Guid.NewGuid(),
            Name = "John",
            FirstOrderDate = fakeTimeProvider.GetUtcNow().UtcDateTime.AddMonths(-11),
            LastOrderDate = fakeTimeProvider.GetUtcNow().UtcDateTime.AddMonths(-8),
            IsActive = true,
        });

        await context.SaveChangesAsync();

        var sut = new Worker(fakeTimeProvider);

        // Act
        var result = await sut.ArchiveOldClientsAsync(context);

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public async Task WhenSeedDatabaseAsyncIsInvoked_ThenExpectedNumberOfClientsAreCreated()
    {
        // Arrange
        var context = InitializeDatabase();
        var fakeTimeProvider = new FakeTimeProvider();

        var sut = new Worker(fakeTimeProvider);

        // Act
        var result = await sut.SeedDatabaseAsync(context);

        // Assert
        result.Should().Be(10);
    }

    private ApplicationDbContext InitializeDatabase()
    {
        var connectionString = _msSqlContainer.GetConnectionString();
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        return new ApplicationDbContext(options);
    }

    public Task InitializeAsync()
        => _msSqlContainer.StartAsync();

    public Task DisposeAsync()
        => _msSqlContainer.DisposeAsync().AsTask();
}
