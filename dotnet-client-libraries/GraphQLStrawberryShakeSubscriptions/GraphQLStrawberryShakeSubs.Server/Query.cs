using GraphQLStrawberryShakeSubs.Server.Data;

namespace GraphQLStrawberryShakeSubs.Server;

public class Query
{
    public IEnumerable<ShippingContainer> GetShippingContainers([Service] ApplicationDbContext dbContext) =>
        dbContext.ShippingContainers;
}
