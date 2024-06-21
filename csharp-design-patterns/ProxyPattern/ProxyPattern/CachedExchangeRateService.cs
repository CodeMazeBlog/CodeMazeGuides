namespace ProxyPattern;

public class CachedExchangeRateService : IExchangeRateService
{
    private readonly IExchangeRateService _exchangeRateService;
    private ExchangeRate[]? _exchangeRates;

    public CachedExchangeRateService()
    {
        _exchangeRateService = new ExchangeRateService();
    }

    public ExchangeRate[] GetExchangeRates()
    {
        if (_exchangeRates is null)
        {
            _exchangeRates = _exchangeRateService.GetExchangeRates();

            return _exchangeRates;
        }

        Console.WriteLine("Read data from cache");

        return _exchangeRates;
    }
}