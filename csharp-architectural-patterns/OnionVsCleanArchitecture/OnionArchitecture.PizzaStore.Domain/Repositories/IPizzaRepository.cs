using OnionArchitecture.PizzaStore.Domain.Entities;

namespace OnionArchitecture.PizzaStore.Domain.Repositories;

public interface IPizzaRepository
{
    Task<IEnumerable<Pizza>> GetAllAsync(CancellationToken cancellationToken = default);
}
