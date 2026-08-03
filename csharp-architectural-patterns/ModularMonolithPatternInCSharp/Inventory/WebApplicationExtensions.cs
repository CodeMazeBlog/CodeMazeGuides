using Inventory.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory;

public static class WebApplicationExtensions
{
    public static void UseOrderConsumer(this WebApplication app)
    {
        var orderConsumer = app.Services.GetRequiredService<IRabbitMqConsumer>();
        orderConsumer.Consume();
    }
}
