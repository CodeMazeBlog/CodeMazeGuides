using EventTicketing.Data;
using EventTicketing.Features.Reservations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EventTicketing.Tests;

public sealed class ReserveTicketsTests : IDisposable
{
    private readonly SqliteConnection _connection = new("Data Source=:memory:");

    public ReserveTicketsTests() => _connection.Open();

    public void Dispose() => _connection.Dispose();

    private TicketingDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<TicketingDbContext>()
            .UseSqlite(_connection)
            .Options;

        var dbContext = new TicketingDbContext(options);
        dbContext.Database.EnsureCreated();

        return dbContext;
    }

    [Fact]
    public async Task HandleAsync_WhenTicketsAreAvailable_SavesTheReservation()
    {
        var handler = new ReserveTickets.Handler(CreateDbContext());

        var result = await handler.HandleAsync(eventId: 1, quantity: 3, TestContext.Current.CancellationToken);

        Assert.True(result.IsSuccess);
        Assert.Equal(97, result.Value.TicketsLeft);

        var saved = await CreateDbContext().Events.SingleAsync(e => e.Id == 1, TestContext.Current.CancellationToken);
        Assert.Equal(3, saved.TicketsSold);
    }

    [Fact]
    public async Task HandleAsync_WhenTheEventIsSoldOut_SavesNothing()
    {
        var handler = new ReserveTickets.Handler(CreateDbContext());

        var result = await handler.HandleAsync(eventId: 2, quantity: 3, TestContext.Current.CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal("Event.SoldOut", result.Error!.Code);

        var saved = await CreateDbContext().Events.SingleAsync(e => e.Id == 2, TestContext.Current.CancellationToken);
        Assert.Equal(0, saved.TicketsSold);
    }
}
