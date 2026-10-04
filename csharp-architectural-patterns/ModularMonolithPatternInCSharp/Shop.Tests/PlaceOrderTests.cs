using Shop.Contracts.Inventory;
using Shop.Orders;
using Shop.Orders.Features;
using Shop.Shared;

namespace Shop.Tests;

public class PlaceOrderTests
{
    [Fact]
    public async Task HandleAsync_WhenInventoryReservesTheStock_StoresTheOrder()
    {
        var inventory = new FakeInventoryModule(
            new StockReservation(ItemId: 1, ItemName: "Mechanical keyboard", UnitPrice: 89.99m, Quantity: 2));
        var orders = new OrderStore();
        var handler = new PlaceOrder.Handler(inventory, orders);

        var result = await handler.HandleAsync(
            new PlaceOrder.Request(ItemId: 1, Quantity: 2), TestContext.Current.CancellationToken);

        Assert.True(result.IsSuccess);
        Assert.Equal(179.98m, result.Value.Total);
        Assert.NotNull(orders.Find(result.Value.OrderId));
    }

    [Fact]
    public async Task HandleAsync_WhenInventorySaysNo_StoresNothing()
    {
        var inventory = new FakeInventoryModule(
            new Error("Item.OutOfStock", "Only 2 of item 2 left, 3 requested.", ErrorType.Conflict));
        var orders = new OrderStore();
        var handler = new PlaceOrder.Handler(inventory, orders);

        var result = await handler.HandleAsync(
            new PlaceOrder.Request(ItemId: 2, Quantity: 3), TestContext.Current.CancellationToken);

        Assert.False(result.IsSuccess);
        Assert.Equal("Item.OutOfStock", result.Error!.Code);
        Assert.Null(orders.Find(1));
    }
}

internal sealed class FakeInventoryModule(Result<StockReservation> answer) : IInventoryModule
{
    public Task<Result<StockReservation>> ReserveStockAsync(
        int itemId, int quantity, CancellationToken cancellationToken = default) =>
        Task.FromResult(answer);
}
