using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Shop.Contracts.Inventory;
using Shop.Contracts.Orders;
using Shop.Inventory.Application;
using Shop.Inventory.Infrastructure;
using Shop.Shared;

namespace Shop.Inventory;

public static class InventoryModule
{
    public static IServiceCollection AddInventoryModule(this IServiceCollection services)
    {
        services.AddSingleton<IItemRepository, InMemoryItemRepository>();
        services.AddScoped<InventoryService>();
        services.AddScoped<IInventoryModule>(sp => sp.GetRequiredService<InventoryService>());
        services.AddScoped<IIntegrationEventHandler<OrderCancelled>, ReleaseStockWhenOrderCancelled>();

        return services;
    }

    public static void MapInventoryEndpoints(this IEndpointRouteBuilder app)
    {
        var inventory = app.MapGroup("/api/inventory");

        inventory.MapGet("/items/{itemId:int}", async (
            int itemId,
            InventoryService service,
            CancellationToken cancellationToken) =>
        {
            var result = await service.GetItemAsync(itemId, cancellationToken);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblem();
        });
    }
}
