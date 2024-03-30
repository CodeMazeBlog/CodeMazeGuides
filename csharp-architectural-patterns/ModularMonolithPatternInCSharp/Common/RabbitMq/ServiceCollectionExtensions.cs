using Microsoft.Extensions.DependencyInjection;

namespace Common.RabbitMq;

public static class ServiceCollectionExtensions
{
    public static void AddRabbitMqConnectionManager(this IServiceCollection services)
    {
        services.AddSingleton<IRabbitMqConnectionManager, RabbitMqConnectionManager>();
    }
}
