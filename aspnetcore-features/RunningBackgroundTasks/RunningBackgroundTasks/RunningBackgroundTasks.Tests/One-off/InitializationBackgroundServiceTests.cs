namespace RunningBackgroundTasks.Tests.One_off;

public class InitializationBackgroundServiceTests
{
    [Fact]
    public async Task WhenExecuteAsyncIsInvoked_ThenSeedDatabaseAsyncMethodIsCalledOnce()
    {
        // Arrange
        var worker = Substitute.For<IWorker>();
        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("someDb"))
            .BuildServiceProvider();
        var sut = new InitializationHostedService(worker, serviceProvider);

        // Act
        await sut.StartAsync(CancellationToken.None);

        // Assert
        await worker.ReceivedWithAnyArgs(1)
            .SeedDatabaseAsync(
                Arg.Any<ApplicationDbContext>(),
                Arg.Any<CancellationToken>());
    }
}
