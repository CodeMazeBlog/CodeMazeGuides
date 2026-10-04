using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Shop.Contracts.Inventory;
using Shop.Shared;

namespace Shop.Orders.Features;

internal static class PlaceOrder
{
    public sealed record Request(int ItemId, [property: Range(1, 10)] int Quantity);

    public sealed record Response(int OrderId, string ItemName, int Quantity, decimal Total);

    public sealed class Handler(IInventoryModule inventory, OrderStore orders)
    {
        public async Task<Result<Response>> HandleAsync(
            Request request, CancellationToken cancellationToken = default)
        {
            var reservation = await inventory.ReserveStockAsync(
                request.ItemId, request.Quantity, cancellationToken);
            if (!reservation.IsSuccess)
                return reservation.Error!;

            var stock = reservation.Value;
            var order = orders.Add(stock.ItemId, stock.Quantity, stock.UnitPrice * stock.Quantity);

            return new Response(order.Id, stock.ItemName, order.Quantity, order.Total);
        }
    }

    public static void MapPlaceOrder(this IEndpointRouteBuilder app) =>
        app.MapPost("/", async (Request request, Handler handler, CancellationToken cancellationToken) =>
        {
            var result = await handler.HandleAsync(request, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });
}
