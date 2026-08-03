using MediatR;
using CleanArchitecture.PizzaStore.Domain.Entities;
using CleanArchitecture.PizzaStore.Domain.Repositories;

namespace CleanArchitecture.PizzaStore.Application.UseCases;

public class GetPizzasQueryHandler(IPizzaRepository pizzaRepository) : IRequestHandler<GetPizzasQuery, IEnumerable<Pizza>>
{
    public async Task<IEnumerable<Pizza>> Handle(GetPizzasQuery request, CancellationToken cancellationToken)
    {
        return await pizzaRepository.GetAllAsync(cancellationToken);
    }
}
