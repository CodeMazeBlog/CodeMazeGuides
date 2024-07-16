using MediatR;
using CleanArchitecture.PizzaStore.Domain.Entities;
using CleanArchitecture.PizzaStore.Domain.Repositories;

namespace CleanArchitecture.PizzaStore.Application.UseCases;

public class PlaceOrderCommandHandler(IOrderRepository orderRepository) : IRequestHandler<PlaceOrderCommand>
{    
    public async Task Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        await orderRepository.PlaceOrderAsync(new Order
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            Name = request.Name,
            Phone = request.Phone,
            Pizzas = request.Pizzas
        }, cancellationToken);
    }
}
