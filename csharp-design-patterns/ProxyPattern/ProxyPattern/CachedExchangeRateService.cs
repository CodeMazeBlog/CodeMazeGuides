namespace ProxyPattern;

public class CachedExchangeRateService : IExchangeRateService
{
    private readonly IExchangeRateService _exchangeRateService;
    private ExchangeRate[]? _exhangeRates;

    public CachedExchangeRateService()
    {
        _exchangeRateService = new ExchangeRateService();
    }

    public ExchangeRate[] GetExchangeRates()
    {
        if (_exhangeRates is null)
        {
            _exhangeRates = _exchangeRateService.GetExchangeRates();

            return _exhangeRates;
        }

        Console.WriteLine("Read data from cache");

        return _exhangeRates;
    }
}