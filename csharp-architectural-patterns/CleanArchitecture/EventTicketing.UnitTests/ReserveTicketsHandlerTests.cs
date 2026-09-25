using EventTicketing.Application;
using EventTicketing.Domain;

namespace EventTicketing.UnitTests;

public class ReserveTicketsHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenTicketsAreAvailable_ReservesAndSaves()
    {
        var events = new FakeEventRepository(Event.Create("Clean Architecture Live", capacity: 100));
        var handler = new ReserveTicketsHandler(events);

        var result = await handler.HandleAsync(
            new ReserveTicketsCommand(EventId: 1, Quantity: 2), TestContext.Current.CancellationToken);

        Assert.True(result.IsSuccess);
        Assert.Equal(98, result.Value.TicketsLeft);
        Assert.Equal(1, events.SaveCount);
    }

    [Fact]
    public async Task HandleAsync_WhenEventIsSoldOut_SavesNothing()
    {
        var events = new FakeEventRepository(Event.Create("Tiny Jazz Club Night", capacity: 1));
        var handler = new ReserveTicketsHandler(events);

        var result = await handler.HandleAsync(
            new ReserveTicketsCommand(EventId: 1, Quantity: 2), TestContext.Current.CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal("Event.SoldOut", result.Error!.Code);
        Assert.Equal(0, events.SaveCount);
    }
}

internal sealed class FakeEventRepository(Event? ev) : IEventRepository
{
    public int SaveCount { get; private set; }

    public Task<Event?> GetByIdAsync(int eventId, CancellationToken cancellationToken = default) =>
        Task.FromResult(ev);

    public Task<EventAvailability?> GetAvailabilityAsync(int eventId, CancellationToken cancellationToken = default) =>
        Task.FromResult<EventAvailability?>(null);

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SaveCount++;
        return Task.CompletedTask;
    }
}
