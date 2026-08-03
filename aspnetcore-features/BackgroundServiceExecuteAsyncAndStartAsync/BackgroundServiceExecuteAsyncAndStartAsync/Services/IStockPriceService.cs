using BackgroundServiceExecuteAsyncAndStartAsync.Models;

namespace BackgroundServiceExecuteAsyncAndStartAsync.Services;

public interface IStockPriceService
{
    Task<ApiToken> AuthenticateAsync(string username, string password, CancellationToken cancellationToken);
    Task<StockPrice[]> GetStockPricesAsync(ApiToken token, CancellationToken cancellationToken);
}
