using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.RabbitMq;

public static class ServiceCollectionExtensions
{
    public static void AddRabbitMqConnectionManager(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IRabbitMqConnectionManager, RabbitMqConnectionManager>();

        services.Configure<RabbitMqConfiguration>(configuration.GetSection(nameof(RabbitMqConfiguration)));
    }
}
