using EventTicketing.Domain;

namespace EventTicketing.UnitTests;

public class EventTests
{
    [Fact]
    public void Reserve_WhenEnoughTicketsAreLeft_SellsThem()
    {
        var ev = Event.Create("Clean Architecture Live", capacity: 100);

        var result = ev.Reserve(3);

        Assert.True(result.IsSuccess);
        Assert.Equal(97, ev.TicketsLeft);
    }

    [Fact]
    public void Reserve_WhenTooFewTicketsAreLeft_ReturnsSoldOutAndSellsNothing()
    {
        var ev = Event.Create("Tiny Jazz Club Night", capacity: 2);

        var result = ev.Reserve(3);

        Assert.False(result.IsSuccess);
        Assert.Equal("Event.SoldOut", result.Error!.Code);
        Assert.Equal(0, ev.TicketsSold);
    }
}
