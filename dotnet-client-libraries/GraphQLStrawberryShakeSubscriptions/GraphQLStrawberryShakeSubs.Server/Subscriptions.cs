using GraphQLStrawberryShakeSubs.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQLStrawberryShakeSubs.Server;

public class Subscriptions
{
    [Subscribe]
    [Topic]
    public async Task<ShippingContainer> OnShippingContainerAddedAsync(
        [EventMessage] string shippingContainerId,
        [Service] ApplicationDbContext dbContext,
        CancellationToken cancellationToken) => await dbContext.ShippingContainers
            .FirstAsync(x => x.Id == shippingContainerId, cancellationToken);

    [Subscribe]
    [Topic]
    public async Task<ShippingContainer> OnShippingContainerSpaceChangedAsync(
        [EventMessage] string shippingContainerName,
        [Service] ApplicationDbContext dbContext,
        CancellationToken cancellationToken) => await dbContext.ShippingContainers
            .FirstAsync(x => x.Name == shippingContainerName, cancellationToken);
}
