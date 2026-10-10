namespace Shop.Contracts.Orders;

public sealed record OrderCancelled(int OrderId, int ItemId, int Quantity);
