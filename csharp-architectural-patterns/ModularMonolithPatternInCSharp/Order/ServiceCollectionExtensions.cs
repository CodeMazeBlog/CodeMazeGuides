using Microsoft.Extensions.DependencyInjection;
using Order.Interfaces;
using Order.Repositories;
using Order.Services;

namespace Order;

public static class ServiceCollectionExtensions
{
    public static void AddOrderModule(this IServiceCollection services)
    {
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IInventoryRestClient, InventoryRestClient>();
        services.AddTransient<IInventoryRabbitMqClient, InventoryRabbitMqClient>();
    }
}
