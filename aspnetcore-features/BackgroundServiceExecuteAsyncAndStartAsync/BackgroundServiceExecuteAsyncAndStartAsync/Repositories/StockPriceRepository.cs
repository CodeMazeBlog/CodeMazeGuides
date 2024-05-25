using BackgroundServiceExecuteAsyncAndStartAsync.Data;
using BackgroundServiceExecuteAsyncAndStartAsync.Models;
using Microsoft.EntityFrameworkCore;

namespace BackgroundServiceExecuteAsyncAndStartAsync.Repositories;

public class StockPriceRepository(StockPricesDbContext dbContext) : IStockPriceRepository
{
    public async Task AddRangeAsync(StockPrice[] stockPrices, CancellationToken cancellationToken)
    {
        await dbContext.StockPrices.AddRangeAsync(stockPrices, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<StockPrice>> GetTodayStockPricesAsync()
    {
        return await dbContext.StockPrices
                        .Where(s => s.MeasurementTimeStamp.Date == DateTime.Today)
                        .OrderByDescending(s => s.MeasurementTimeStamp)
                        .AsNoTracking()
                        .ToListAsync();
    }
}
