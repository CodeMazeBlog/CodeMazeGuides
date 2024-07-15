using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Repositories;

public interface IOrderRepository
{
    Task PlaceOrderAsync(Order order, CancellationToken cancellationToken = default);
}
