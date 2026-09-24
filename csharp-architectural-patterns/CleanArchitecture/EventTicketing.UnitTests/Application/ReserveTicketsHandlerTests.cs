using EventTicketing.Application.Events;
using EventTicketing.Domain.Events;

namespace EventTicketing.UnitTests.Application;

public class ReserveTicketsHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenTicketsAreAvailable_ReservesAndSaves()
    {
        var unitOfWork = new FakeUnitOfWork();
        var ev = Event.Create("Clean Architecture Live", capacity: 100);
        var handler = new ReserveTicketsHandler(new FakeEventRepository(ev), unitOfWork);

        var result = await handler.HandleAsync(
            new ReserveTicketsCommand(EventId: 1, Quantity: 2), TestContext.Current.CancellationToken);

        Assert.True(result.IsSuccess);
        Assert.Equal(98, result.Value.TicketsLeft);
        Assert.Equal(1, unitOfWork.SaveCount);
    }

    [Fact]
    public async Task HandleAsync_WhenEventIsSoldOut_ReturnsConflictAndSavesNothing()
    {
        var unitOfWork = new FakeUnitOfWork();
        var ev = Event.Create("Clean Architecture Live", capacity: 1);
        var handler = new ReserveTicketsHandler(new FakeEventRepository(ev), unitOfWork);

        var result = await handler.HandleAsync(
            new ReserveTicketsCommand(EventId: 1, Quantity: 2), TestContext.Current.CancellationToken);

        Assert.True(result.IsFailure);
        Assert.Equal("Event.SoldOut", result.Error.Code);
        Assert.Equal(0, unitOfWork.SaveCount);
    }

    [Fact]
    public async Task HandleAsync_WhenEventDoesNotExist_ReturnsNotFound()
    {
        var handler = new ReserveTicketsHandler(new FakeEventRepository(null), new FakeUnitOfWork());

        var result = await handler.HandleAsync(
            new ReserveTicketsCommand(EventId: 42, Quantity: 2), TestContext.Current.CancellationToken);

        Assert.True(result.IsFailure);
        Assert.Equal("Event.NotFound", result.Error.Code);
    }
}
