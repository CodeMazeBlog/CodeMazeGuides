using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Repositories;

public interface IPizzaRepository
{
    Task<IEnumerable<Pizza>> GetAllAsync(CancellationToken cancellationToken = default);
}