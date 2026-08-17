using MediatR;

namespace CqrsAndMediatRInAspNetCore.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}
