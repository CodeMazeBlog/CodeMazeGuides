namespace BackgroundServiceExecuteAsyncAndStartAsync.Models;

public record StockPrice(Guid Id, string Symbol, decimal Price, DateTime ValueDateTime, DateTime MeasurementTimeStamp);