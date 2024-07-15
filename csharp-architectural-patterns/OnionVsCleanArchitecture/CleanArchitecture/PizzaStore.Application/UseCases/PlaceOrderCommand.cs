using MediatR;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Application.UseCases;

public class PlaceOrderCommand : IRequest
{
    public string Name { get; init; } = default!;
    public int Phone { get; init; } = default!;
    public IEnumerable<Pizza> Pizzas { get; init; } = default!;
}
