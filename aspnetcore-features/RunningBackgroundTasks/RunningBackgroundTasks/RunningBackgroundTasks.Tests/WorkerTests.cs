namespace RunningBackgroundTasks.Tests;

public sealed class WorkerTests
{
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
        await context.DisposeAsync();
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
        await context.DisposeAsync();
    }

    private static ApplicationDbContext InitializeDatabase()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("someDb")
            .Options;

        return new ApplicationDbContext(options);
    }
}
