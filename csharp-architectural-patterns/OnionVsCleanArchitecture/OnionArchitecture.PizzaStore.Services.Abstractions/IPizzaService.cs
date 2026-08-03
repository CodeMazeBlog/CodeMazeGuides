using OnionArchitecture.PizzaStore.Contracts;
using OnionArchitecture.PizzaStore.Domain.Entities;

namespace OnionArchitecture.PizzaStore.Services.Abstractions;

public interface IPizzaService
{
    Task PlaceOrderAsync(OrderDto orderDto, CancellationToken cancellationToken = default);
    Task<IEnumerable<PizzaDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
