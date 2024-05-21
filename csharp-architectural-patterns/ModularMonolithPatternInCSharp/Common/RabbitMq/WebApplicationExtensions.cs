using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Common.RabbitMq;

public static class WebApplicationExtensions
{
    public static void UseRabbitMqConnectionManager(this WebApplication app)
    {
        var rabbitMqConnectionManager = app.Services.GetRequiredService<IRabbitMqConnectionManager>();
        rabbitMqConnectionManager.InitializeConnection();
    }
}
