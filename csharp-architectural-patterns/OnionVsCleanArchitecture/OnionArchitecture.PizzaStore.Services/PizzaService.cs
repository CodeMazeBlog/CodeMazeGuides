using OnionArchitecture.PizzaStore.Contracts;
using OnionArchitecture.PizzaStore.Domain.Entities;
using OnionArchitecture.PizzaStore.Domain.Exceptions;
using OnionArchitecture.PizzaStore.Domain.Repositories;
using OnionArchitecture.PizzaStore.Services.Abstractions;

namespace OnionArchitecture.PizzaStore.Services;
public class PizzaService(IPizzaRepository pizzaRepository, IOrderRepository orderRepository) : IPizzaService
{
    public async Task<IEnumerable<PizzaDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var pizzas = await pizzaRepository.GetAllAsync(cancellationToken);

        var pizzasDto = new List<PizzaDto>(pizzas.Select(pizza => new PizzaDto()
        {
            Name = pizza.Name
        }));
        return pizzasDto;
    }

    public async Task PlaceOrderAsync(OrderDto orderDto, CancellationToken cancellationToken = default)
    {
        if (orderDto.Pizzas.Count() > 5)
        {
            throw new MaximumPizzasPerOrderException();
        }

        var pizzas = await pizzaRepository.GetAllAsync(cancellationToken);

        var order = new Order
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            Name = orderDto.Name,
            Phone = orderDto.Phone,
            Pizzas = from p in orderDto.Pizzas
                     join p2 in pizzas
                     on p.Name equals p2.Name
                     select p2
        };

        await orderRepository.PlaceOrderAsync(order, cancellationToken);
    }
}
