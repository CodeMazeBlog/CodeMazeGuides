using BackgroundServiceExecuteAsyncAndStartAsync.Models;

namespace BackgroundServiceExecuteAsyncAndStartAsync.Services;

public class StockPriceService : IStockPriceService
{
    public async Task<ApiToken> AuthenticateAsync(string username, string password, CancellationToken cancellationToken)
    {
        await Task.Delay(50, cancellationToken);// pretend network call
        
        ApiToken apiToken;
        if (username.Equals(password, StringComparison.InvariantCultureIgnoreCase))
            apiToken = new ApiToken(Guid.NewGuid());
        else
            apiToken = new ApiToken(Guid.Empty);

        return apiToken;
    }

    public async Task<StockPrice[]> GetStockPricesAsync(ApiToken token, CancellationToken cancellationToken)
    {
        var measurementTimeStamp = DateTime.UtcNow;
        await Task.Delay(50, cancellationToken);// pretend network call

        if (token.Token == Guid.Empty)
            return [];

        return GenerateStockPrices(measurementTimeStamp);
    }

    private static StockPrice[] GenerateStockPrices(DateTime measurementTimeStamp)
    {
        var stockPrices = new StockPrice[] 
        {
            new(Guid.NewGuid(), "MSFT", new decimal(Random.Shared.NextDouble() * 100), DateTime.UtcNow, measurementTimeStamp),
            new(Guid.NewGuid(), "AAPL", new decimal(Random.Shared.NextDouble() * 100), DateTime.UtcNow, measurementTimeStamp),
            new(Guid.NewGuid(), "GOOG", new decimal(Random.Shared.NextDouble() * 100), DateTime.UtcNow, measurementTimeStamp),
            new(Guid.NewGuid(), "TSLA", new decimal(Random.Shared.NextDouble() * 100), DateTime.UtcNow, measurementTimeStamp),
            new(Guid.NewGuid(), "NVDA", new decimal(Random.Shared.NextDouble() * 100), DateTime.UtcNow, measurementTimeStamp),
            new(Guid.NewGuid(), "AMD", new decimal(Random.Shared.NextDouble() * 100), DateTime.UtcNow, measurementTimeStamp),
            new(Guid.NewGuid(), "META", new decimal(Random.Shared.NextDouble() * 100), DateTime.UtcNow, measurementTimeStamp),
            new(Guid.NewGuid(), "BABA", new decimal(Random.Shared.NextDouble() * 100), DateTime.UtcNow, measurementTimeStamp),
            new(Guid.NewGuid(), "INTC", new decimal(Random.Shared.NextDouble() * 100), DateTime.UtcNow, measurementTimeStamp),
            new(Guid.NewGuid(), "ORCL", new decimal(Random.Shared.NextDouble() * 100), DateTime.UtcNow, measurementTimeStamp),
            new(Guid.NewGuid(), "SAP", new decimal(Random.Shared.NextDouble() * 100), DateTime.UtcNow, measurementTimeStamp)
        };

        return stockPrices;

    }
}