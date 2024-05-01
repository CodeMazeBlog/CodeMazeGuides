using BackgroundServiceExecuteAsyncAndStartAsync.Models;
using Microsoft.EntityFrameworkCore;

namespace BackgroundServiceExecuteAsyncAndStartAsync.Data;

public class StockPricesDbContext : DbContext
{
    public StockPricesDbContext()
    {
    }

    public StockPricesDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<StockPrice> StockPrices { get; set; }
}