namespace CleanArchitecture.PizzaStore.Domain.Entities;
public class Order
{
    public Guid Id { get; init; } = default!;
    public DateTime Date { get; init; } = default!;
    public string Name { get; init; } = default!;
    public int Phone { get; init; } = default!;
    public IEnumerable<Pizza> Pizzas { get; init; } = default!;
}