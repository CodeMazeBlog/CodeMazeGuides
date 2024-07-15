using PizzaStore.Domain.Entities;
using PizzaStore.Domain.Repositories;

namespace PizzaStore.Persistence;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public Task PlaceOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        _orders.Add(order);
        return Task.CompletedTask;
    }
}
