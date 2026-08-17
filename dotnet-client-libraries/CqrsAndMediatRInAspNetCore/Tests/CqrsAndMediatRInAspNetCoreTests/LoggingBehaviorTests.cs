using CqrsAndMediatRInAspNetCore;
using CqrsAndMediatRInAspNetCore.Behaviors;
using CqrsAndMediatRInAspNetCore.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;

namespace CqrsAndMediatRInAspNetCoreTests;

public class LoggingBehaviorTests
{
    [Fact]
    public async Task WhenHandle_ThenPassesResponseThroughAndLogsBeforeAndAfter()
    {
        var loggerMock = new Mock<ILogger<LoggingBehavior<GetProductsQuery, IEnumerable<Product>>>>();
        var behavior = new LoggingBehavior<GetProductsQuery, IEnumerable<Product>>(loggerMock.Object);
        var expected = new List<Product> { new() { Id = 1, Name = "Test Product 1" } };
        RequestHandlerDelegate<IEnumerable<Product>> next = _ => Task.FromResult<IEnumerable<Product>>(expected);

        var result = await behavior.Handle(new GetProductsQuery(), next, CancellationToken.None);

        Assert.Same(expected, result);
        loggerMock.Verify(
            l => l.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Exactly(2));
    }
}
