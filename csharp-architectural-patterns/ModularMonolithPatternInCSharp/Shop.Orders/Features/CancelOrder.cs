using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Shop.Contracts.Orders;
using Shop.Shared;

namespace Shop.Orders.Features;

internal static class CancelOrder
{
    public sealed record Response(int OrderId, string Status);

    public sealed class Handler(OrderStore orders, IEventBus eventBus)
    {
        public async Task<Result<Response>> HandleAsync(
            int orderId, CancellationToken cancellationToken = default)
        {
            var order = orders.Find(orderId);
            if (order is null)
                return OrderErrors.NotFound(orderId);

            var cancellation = order.Cancel();
            if (!cancellation.IsSuccess)
                return cancellation.Error!;

            await eventBus.PublishAsync(
                new OrderCancelled(order.Id, order.ItemId, order.Quantity), cancellationToken);

            return new Response(order.Id, order.Status.ToString());
        }
    }

    public static void MapCancelOrder(this IEndpointRouteBuilder app) =>
        app.MapPost("/{orderId:int}/cancel", async (
            int orderId, Handler handler, CancellationToken cancellationToken) =>
        {
            var result = await handler.HandleAsync(orderId, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });
}
