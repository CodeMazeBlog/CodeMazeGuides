using MediatR;
using PizzaStore.Domain.Entities;
using PizzaStore.Domain.Repositories;

namespace PizzaStore.Application.UseCases;

public class GetPizzasQueryHandler(IPizzaRepository pizzaRepository) : IRequestHandler<GetPizzasQuery, IEnumerable<Pizza>>
{
    public async Task<IEnumerable<Pizza>> Handle(GetPizzasQuery request, CancellationToken cancellationToken)
    {
        return await pizzaRepository.GetAllAsync(cancellationToken);
    }
}
