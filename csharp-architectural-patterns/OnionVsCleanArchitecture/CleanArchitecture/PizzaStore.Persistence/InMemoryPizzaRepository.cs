using PizzaStore.Domain.Entities;
using PizzaStore.Domain.Repositories;

namespace PizzaStore.Persistence;

public class InMemoryPizzaRepository : IPizzaRepository
{
    private readonly List<Pizza> _pizzas =
    [
        new()
        {
            Name = "Ham & Pineapple",
            IsVegetarian = false,
            Price = 10
        },
        new()
        {
            Name = "Meatlovers",
            IsVegetarian = false,
            Price = 12
        },
        new()
        {
            Name = "Mushroom",
            IsVegetarian = true,
            Price = 9
        }
    ];

    public Task<IEnumerable<Pizza>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_pizzas.AsEnumerable());
    }
}
