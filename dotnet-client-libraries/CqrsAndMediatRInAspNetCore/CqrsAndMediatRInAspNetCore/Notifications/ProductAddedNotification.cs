using MediatR;

namespace CqrsAndMediatRInAspNetCore.Notifications
{
	public record ProductAddedNotification(Product Product) : INotification;
}
