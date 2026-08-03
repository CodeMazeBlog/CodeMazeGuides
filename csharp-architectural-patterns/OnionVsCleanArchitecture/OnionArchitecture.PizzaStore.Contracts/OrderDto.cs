namespace OnionArchitecture.PizzaStore.Contracts;

public class OrderDto
{    
    public string Name { get; init; } = default!;
    public int Phone { get; init; } = default!;
    public IEnumerable<PizzaDto> Pizzas { get; init; } = default!;
}