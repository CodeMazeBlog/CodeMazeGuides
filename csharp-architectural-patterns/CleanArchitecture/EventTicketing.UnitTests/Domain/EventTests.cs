using EventTicketing.Domain.Common;
using EventTicketing.Domain.Events;

namespace EventTicketing.UnitTests.Domain;

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
        var ev = Event.Create("Clean Architecture Live", capacity: 2);

        var result = ev.Reserve(3);

        Assert.True(result.IsFailure);
        Assert.Equal("Event.SoldOut", result.Error.Code);
        Assert.Equal(0, ev.TicketsSold);
    }

    [Fact]
    public void Reserve_WithNonPositiveQuantity_Throws()
    {
        var ev = Event.Create("Clean Architecture Live", capacity: 100);

        Assert.Throws<DomainException>(() => ev.Reserve(0));
    }
}
