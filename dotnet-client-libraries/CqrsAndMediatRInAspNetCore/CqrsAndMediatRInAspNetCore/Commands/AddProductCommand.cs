using MediatR;

namespace CqrsAndMediatRInAspNetCore.Commands
{
	public record AddProductCommand(Product Product) : IRequest<Product>;
}
