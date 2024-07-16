using OnionArchitecture.PizzaStore.Domain.Entities;
using OnionArchitecture.PizzaStore.Domain.Repositories;

namespace OnionArchitecture.PizzaStore.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();
        
    public Task PlaceOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        _orders.Add(order);
        return Task.CompletedTask;
    }
}
