using Inventory.Repositories;
using Inventory.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory;

public static class DependencyInjection
{
    public static void AddInventoryModule(this IServiceCollection services)
    {
        services.AddTransient<IItemService, ItemService>();
        services.AddTransient<IItemRepository, ItemRepository>();
        services.AddTransient<IRabbitMqConsumer, RabbitMqConsumer>();

        var serviceProvider = services.BuildServiceProvider();
        var rabbitMqConsumer = serviceProvider.GetRequiredService<IRabbitMqConsumer>();

        rabbitMqConsumer.Consume();
    }
}
