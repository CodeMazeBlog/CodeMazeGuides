using BackgroundServiceExecuteAsyncAndStartAsync.Models;

namespace BackgroundServiceExecuteAsyncAndStartAsync.Repositories;

public interface IStockPriceRepository
{
    Task<IReadOnlyCollection<StockPrice>> GetTodayStockPricesAsync();
    Task AddRangeAsync(StockPrice[] stockPrices, CancellationToken cancellationToken);
}