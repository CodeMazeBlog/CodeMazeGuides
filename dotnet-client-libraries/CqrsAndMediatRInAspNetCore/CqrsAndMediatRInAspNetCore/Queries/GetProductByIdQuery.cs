using MediatR;

namespace CqrsAndMediatRInAspNetCore.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
