using HotChocolate;

namespace GraphQLStrawberryShake.Server;

public class Query
{
    public IEnumerable<ShippingContainer> GetShippingContainers([Service] ApplicationDbContext dbContext) =>
        dbContext.ShippingContainers;
}
