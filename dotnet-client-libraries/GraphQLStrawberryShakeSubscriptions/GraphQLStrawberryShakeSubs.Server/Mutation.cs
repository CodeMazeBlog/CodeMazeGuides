using GraphQLStrawberryShakeSubs.Server.Data;

namespace GraphQLStrawberryShakeSubs.Server;

public class Mutation
{
    public async Task<bool> AddAvaliableShippingContainerAsync(
        ShippingContainer shippingContainer,
        [Service] ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        try
        {
            dbContext.ShippingContainers.Add(shippingContainer);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return false;
        }

        return true;
    }

    //public async Task<bool> UpdateShippingContainerAsync(
    //    ShippingContainer shippingContainer,
    //    [Service] ApplicationDbContext dbContext,
    //    CancellationToken cancellationToken)
    //{
    //    try
    //    {
    //        dbContext.ShippingContainers.Update(shippingContainer);
    //        await dbContext.SaveChangesAsync(cancellationToken);
    //    }
    //    catch (Exception exception)
    //    {
    //        Console.WriteLine(exception.Message);
    //        return false;
    //    }

    //    return true;
    //}
}
