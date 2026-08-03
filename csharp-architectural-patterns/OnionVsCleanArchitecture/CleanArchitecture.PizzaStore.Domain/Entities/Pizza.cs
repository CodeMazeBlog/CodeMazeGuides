namespace CleanArchitecture.PizzaStore.Domain.Entities;

public class Pizza
{
    public string Name { get; init; } = default!;
    public bool IsVegetarian { get; init; } = default!;
    public int Price { get; init; } = default!;
}