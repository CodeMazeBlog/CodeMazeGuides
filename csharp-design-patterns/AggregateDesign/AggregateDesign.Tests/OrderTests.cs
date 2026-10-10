using AggregateDesign.Domain;

namespace AggregateDesign.Tests;

public class OrderTests
{
    private const string Shoes = "Cloudsoft Women's Running Shoes";
    private const string TShirt = "Gildone Men's Crew T-Shirt";

    private static Order NewOrder()
    {
        var order = Order.Create(TimeProvider.System);
        order.AddItem(Shoes, 1, 59.99m);
        order.AddItem(TShirt, 3, 18.99m);

        return order;
    }

    [Fact]
    public void AddPayment_WhenItCoversTheTotal_MakesTheOrderReadyForShipping()
    {
        var order = NewOrder();

        var result = order.AddPayment(116.96m);

        Assert.True(result.IsSuccess);
        Assert.Equal(OrderStatus.ReadyForShipping, order.Status);
    }

    [Fact]
    public void AddPayment_WhenItExceedsTheAmountDue_ReturnsOverpayment()
    {
        var order = NewOrder();

        var result = order.AddPayment(200m);

        Assert.Equal("Order.Overpayment", result.Error!.Code);
        Assert.Equal(0m, order.PaidAmount);
    }

    [Fact]
    public void RemoveItem_AfterPaymentHasStarted_ReturnsItemsLocked()
    {
        var order = NewOrder();
        order.AddPayment(100m);

        var result = order.RemoveItem(TShirt);

        Assert.Equal("Order.ItemsLocked", result.Error!.Code);
        Assert.Equal(116.96m, order.Total);
    }

    [Fact]
    public void AddQuantity_AfterFullPayment_ReturnsItemsLocked()
    {
        var order = NewOrder();
        order.AddPayment(order.Total);

        var result = order.AddQuantity(Shoes, 9);

        Assert.Equal("Order.ItemsLocked", result.Error!.Code);
        Assert.Equal(order.PaidAmount, order.Total);
    }

    [Fact]
    public void WithdrawQuantity_WhenItWouldTakeEveryUnit_ReturnsLastUnit()
    {
        var order = NewOrder();

        var result = order.WithdrawQuantity(TShirt, 4);

        Assert.Equal("Order.LastUnit", result.Error!.Code);
        Assert.Equal(3, order.Items.Single(item => item.Name == TShirt).Quantity);
    }

    [Fact]
    public void AddQuantity_ForAnUnknownItem_ReturnsItemNotFound()
    {
        var order = NewOrder();

        var result = order.AddQuantity("Wool Socks", 2);

        Assert.Equal("Order.ItemNotFound", result.Error!.Code);
    }

    [Fact]
    public void AddItem_WithANameAlreadyInTheOrder_ReturnsDuplicateItem()
    {
        var order = NewOrder();

        var result = order.AddItem(Shoes, 1, 59.99m);

        Assert.Equal("Order.DuplicateItem", result.Error!.Code);
        Assert.Equal(2, order.Items.Count);
    }

    [Fact]
    public void AddItem_WithZeroQuantity_Throws()
    {
        var order = Order.Create(TimeProvider.System);

        Assert.Throws<ArgumentOutOfRangeException>(() => order.AddItem(Shoes, 0, 59.99m));
    }

    [Fact]
    public void Ship_WhenNotPaidInFull_ReturnsNotPaid()
    {
        var order = NewOrder();
        order.AddPayment(20m);

        var result = order.Ship(TimeProvider.System);

        Assert.Equal("Order.NotPaid", result.Error!.Code);
        Assert.Equal(OrderStatus.PendingPayment, order.Status);
    }

    [Fact]
    public void Ship_WithNoItems_ReturnsEmpty()
    {
        var order = Order.Create(TimeProvider.System);

        var result = order.Ship(TimeProvider.System);

        Assert.Equal("Order.Empty", result.Error!.Code);
    }

    [Fact]
    public void Ship_WhenPaidInFull_UsesTheClockForTheShippingDate()
    {
        var now = new DateTimeOffset(2026, 10, 1, 9, 30, 0, TimeSpan.Zero);
        var order = NewOrder();
        order.AddPayment(order.Total);

        var result = order.Ship(new FixedClock(now));

        Assert.True(result.IsSuccess);
        Assert.Equal(OrderStatus.InTransit, order.Status);
        Assert.Equal(now.UtcDateTime, order.ShippedAtUtc);
    }

    [Fact]
    public void Ship_Twice_ReturnsAlreadyShipped()
    {
        var order = NewOrder();
        order.AddPayment(order.Total);
        order.Ship(TimeProvider.System);

        var result = order.Ship(TimeProvider.System);

        Assert.Equal("Order.AlreadyShipped", result.Error!.Code);
    }
}

internal sealed class FixedClock(DateTimeOffset now) : TimeProvider
{
    public override DateTimeOffset GetUtcNow() => now;
}
