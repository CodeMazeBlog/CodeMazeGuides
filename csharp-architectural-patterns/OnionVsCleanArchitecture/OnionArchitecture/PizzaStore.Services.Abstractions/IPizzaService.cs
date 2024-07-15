using PizzaStore.Contracts;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Services.Abstractions;

public interface IPizzaService
{
    Task PlaceOrderAsync(OrderDto orderDto, CancellationToken cancellationToken = default);
    Task<IEnumerable<PizzaDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
