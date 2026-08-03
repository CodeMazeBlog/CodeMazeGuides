using MediatR;
using CleanArchitecture.PizzaStore.Domain.Entities;

namespace CleanArchitecture.PizzaStore.Application.UseCases;

public class GetPizzasQuery : IRequest<IEnumerable<Pizza>>
{
}
