using CleanArchitecture.PizzaStore.Domain.Entities;

namespace CleanArchitecture.PizzaStore.Domain.Repositories;

public interface IPizzaRepository
{
    Task<IEnumerable<Pizza>> GetAllAsync(CancellationToken cancellationToken = default);
}