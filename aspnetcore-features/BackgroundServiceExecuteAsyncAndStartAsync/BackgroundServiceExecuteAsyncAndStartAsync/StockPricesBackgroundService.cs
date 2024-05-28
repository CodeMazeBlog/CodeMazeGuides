
using BackgroundServiceExecuteAsyncAndStartAsync.Models;
using BackgroundServiceExecuteAsyncAndStartAsync.Repositories;
using BackgroundServiceExecuteAsyncAndStartAsync.Services;

namespace BackgroundServiceExecuteAsyncAndStartAsync;

public class StockPricesBackgroundService(
    IServiceProvider serviceProvider,
    IStockPriceService stockPriceService) : BackgroundService
{
    private const int RunEveryMilliseconds = 10000;
    private ApiToken? _token = null;

    // ATTENTION
    // Credential and other sensitive information should ALWAYS be stored in storage
    // designed to store secrets (i.e Azure Key Vault, Hashicorp Vault, AWS Secrets Manager)        
    private const string Username = "Secret1234!";
    private const string Password = "Secret1234!";

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        _token = await stockPriceService.AuthenticateAsync(Username, Password, cancellationToken);

        await base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            var stockPriceRepository = scope.ServiceProvider.GetRequiredService<IStockPriceRepository>();

            var prices = await stockPriceService.GetStockPricesAsync(_token!, stoppingToken);
            await stockPriceRepository.AddRangeAsync(prices, stoppingToken);

            await Task.Delay(RunEveryMilliseconds, stoppingToken);
        }
    }
}
