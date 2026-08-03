using OnionArchitecture.PizzaStore.Domain.Entities;

namespace OnionArchitecture.PizzaStore.Domain.Repositories;

public interface IOrderRepository
{
    Task PlaceOrderAsync(Order order, CancellationToken cancellationToken = default);
}
