using GraphQLStrawberryShakeSubs.Server.Data;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GraphQLStrawberryShakeSubs.Server;

public class Mutation
{
    public async Task<AddShippingContainerPayload> AddAvaliableShippingContainerAsync(
        AddShippingContainerInput input,
        [Service] ApplicationDbContext dbContext,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
    {
        AddShippingContainerPayload payload;
        try
        {
            var shippingContainer = new ShippingContainer
            {
                Id = dbContext.ShippingContainers.Count().ToString(),
                Name = input.Name,
                Space = new ShippingContainer.AvailableSpace
                {
                    Length = input.Length,
                    Width = input.Width,
                    Height = input.Height
                }
            };

            dbContext.ShippingContainers.Add(shippingContainer);

            await dbContext.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(
                nameof(Subscriptions.OnShippingContainerAddedAsync),
                shippingContainer.Id,
                cancellationToken);

            payload = new AddShippingContainerPayload(shippingContainer);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return null!;
        }

        return payload;
    }

    public async Task<UpdateShippingContainerPayload> UpdateShippingContainerAsync(
        UpdateShippingContainerInput input,
        [Service] ApplicationDbContext dbContext,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
    {
        UpdateShippingContainerPayload payload;
        try
        {
            var shippingContainer = await dbContext.ShippingContainers.FirstAsync(x => x.Name == input.Name,
                cancellationToken);
            shippingContainer!.Space!.Length = input.Length;
            shippingContainer!.Space!.Width = input.Width;
            shippingContainer!.Space!.Height = input.Height;

            dbContext.ShippingContainers.Update(shippingContainer);
            await dbContext.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(
                nameof(Subscriptions.OnShippingContainerSpaceChangedAsync),
                shippingContainer.Name,
                cancellationToken);

            payload = new UpdateShippingContainerPayload(shippingContainer);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return null!;
        }

        return payload;
    }
}
