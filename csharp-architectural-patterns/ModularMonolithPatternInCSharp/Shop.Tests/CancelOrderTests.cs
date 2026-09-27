using Shop.Contracts.Orders;
using Shop.Orders;
using Shop.Orders.Features;
using Shop.Shared;

namespace Shop.Tests;

public class CancelOrderTests
{
    [Fact]
    public async Task HandleAsync_WhenOrderIsPlaced_PublishesOrderCancelled()
    {
        var orders = new OrderStore();
        var order = orders.Add(itemId: 1, quantity: 2, total: 179.98m);
        var eventBus = new FakeEventBus();
        var handler = new CancelOrder.Handler(orders, eventBus);

        var result = await handler.HandleAsync(order.Id, TestContext.Current.CancellationToken);

        Assert.True(result.IsSuccess);
        Assert.Equal(new OrderCancelled(order.Id, ItemId: 1, Quantity: 2), Assert.Single(eventBus.Published));
    }
}

internal sealed class FakeEventBus : IEventBus
{
    public List<object> Published { get; } = [];

    public ValueTask PublishAsync<TEvent>(TEvent integrationEvent, CancellationToken cancellationToken = default)
        where TEvent : notnull
    {
        Published.Add(integrationEvent);

        return ValueTask.CompletedTask;
    }
}
