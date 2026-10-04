using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Shop.Orders.Features;

namespace Shop.Orders;

public static class OrdersModule
{
    public static IServiceCollection AddOrdersModule(this IServiceCollection services)
    {
        services.AddValidation();
        services.AddSingleton<OrderStore>();
        services.AddScoped<PlaceOrder.Handler>();
        services.AddScoped<CancelOrder.Handler>();

        return services;
    }

    public static void MapOrdersEndpoints(this IEndpointRouteBuilder app)
    {
        var orders = app.MapGroup("/api/orders");

        orders.MapPlaceOrder();
        orders.MapCancelOrder();
    }
}
