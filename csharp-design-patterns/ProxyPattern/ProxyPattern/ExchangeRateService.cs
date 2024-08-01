namespace ProxyPattern;

public class ExchangeRateService : IExchangeRateService
{
    public ExchangeRate[] GetExchangeRates()
    {
        // In real-world application, this data comes from a remote API service
        ExchangeRate[] data = [
            new("CAD", 0.73m),
            new("EUR", 1.07m),
            new("GBP", 1.27m),
        ];

        Console.WriteLine("Fetched data from remote service");

        return data;   
    }
}