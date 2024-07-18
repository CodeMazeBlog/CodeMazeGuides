using RebusSagaPattern.Models;

namespace RebusSagaPattern.Repositories;

public class OrderRepository : IOrderRepository
{
    private Dictionary<Guid, Order> _orders = new();

    public void AddOrder(Order order)
    {
        _orders.TryAdd(order.OrderId, order);
    }

    public Order GetOrderById(Guid orderId)
    {
        if (!_orders.TryGetValue(orderId, out var order))
        {
            order = new Order();
        }

        return order;
    }
}