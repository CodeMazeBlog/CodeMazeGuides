using MediatR;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Application.UseCases;

public class GetPizzasQuery : IRequest<IEnumerable<Pizza>>
{
}
