using RebusSagaPattern.Models;

namespace RebusSagaPattern.Repositories;

public class OrderRepository : IOrderRepository
{
    private Dictionary<Guid, Order> _orders;

    public OrderRepository()
    {
        _orders = new Dictionary<Guid, Order>();
    }

    public Task AddOrder(Order order)
    {
        _orders.TryAdd(order.OrderId, order);

        return Task.CompletedTask;
    }

    public Task<Order> GetOrderById(Guid orderId)
    {
        if (!_orders.TryGetValue(orderId, out var order))
        {
            order = new Order();
        }

        return Task.FromResult(order);
    }
}