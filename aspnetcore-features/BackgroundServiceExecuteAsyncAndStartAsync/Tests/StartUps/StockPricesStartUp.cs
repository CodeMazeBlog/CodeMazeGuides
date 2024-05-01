using BackgroundServiceExecuteAsyncAndStartAsync.Data;
using BackgroundServiceExecuteAsyncAndStartAsync.Services;
using BackgroundServiceExecuteAsyncAndStartAsync;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BackgroundServiceExecuteAsyncAndStartAsync.Controllers;
using BackgroundServiceExecuteAsyncAndStartAsync.Repositories;

namespace Tests.StartUps;

public class StockPricesStartUp
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<StockPricesDbContext>(options =>
                options.UseInMemoryDatabase("StockPrices"));

        services.AddTransient<IStockPriceService, StockPriceService>();
        services.AddTransient<IStockPriceRepository, StockPriceRepository>();
        services.AddHostedService<StockPricesBackgroundService>();

        // Configure services needed for testing
        services.AddControllers()
                .AddApplicationPart(typeof(StockPriceController).Assembly);
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
