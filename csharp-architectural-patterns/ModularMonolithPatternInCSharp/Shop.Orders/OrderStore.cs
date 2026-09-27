using System.Collections.Concurrent;

namespace Shop.Orders;

internal sealed class OrderStore
{
    private readonly ConcurrentDictionary<int, Order> _orders = new();
    private int _lastId;

    public Order Add(int itemId, int quantity, decimal total)
    {
        var order = new Order(Interlocked.Increment(ref _lastId), itemId, quantity, total);
        _orders[order.Id] = order;

        return order;
    }

    public Order? Find(int orderId) => _orders.GetValueOrDefault(orderId);
}
