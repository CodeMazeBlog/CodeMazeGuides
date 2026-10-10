using Shop.Shared;

namespace Shop.Orders;

internal enum OrderStatus
{
    Placed,
    Cancelled
}

internal sealed class Order(int id, int itemId, int quantity, decimal total)
{
    public int Id { get; } = id;
    public int ItemId { get; } = itemId;
    public int Quantity { get; } = quantity;
    public decimal Total { get; } = total;
    public OrderStatus Status { get; private set; } = OrderStatus.Placed;

    public Result Cancel()
    {
        if (Status == OrderStatus.Cancelled)
            return OrderErrors.AlreadyCancelled(Id);

        Status = OrderStatus.Cancelled;

        return Result.Success();
    }
}

internal static class OrderErrors
{
    public static Error NotFound(int orderId) =>
        new("Order.NotFound", $"Order {orderId} was not found.", ErrorType.NotFound);

    public static Error AlreadyCancelled(int orderId) =>
        new("Order.AlreadyCancelled", $"Order {orderId} is already cancelled.", ErrorType.Conflict);
}
