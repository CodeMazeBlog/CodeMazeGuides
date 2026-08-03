using CleanArchitecture.PizzaStore.Domain.Entities;

namespace CleanArchitecture.PizzaStore.Domain.Repositories;

public interface IOrderRepository
{
    Task PlaceOrderAsync(Order order, CancellationToken cancellationToken = default);
}