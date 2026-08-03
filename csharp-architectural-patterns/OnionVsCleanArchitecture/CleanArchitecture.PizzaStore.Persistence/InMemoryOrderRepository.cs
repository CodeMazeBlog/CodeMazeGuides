using CleanArchitecture.PizzaStore.Domain.Entities;
using CleanArchitecture.PizzaStore.Domain.Repositories;

namespace CleanArchitecture.PizzaStore.Persistence;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public Task PlaceOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        _orders.Add(order);
        return Task.CompletedTask;
    }
}
