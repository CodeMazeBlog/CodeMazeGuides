using ProxyPattern;
using System.Text;

namespace ProxyPatternTests;

public class ExchangeRateServiceTests
{
    private readonly StringBuilder _stringBuilder = new();

    public ExchangeRateServiceTests() 
    {
        Console.SetOut(new StringWriter(_stringBuilder));
    }

    [Fact]
    public void GivenDataService_WhenCalledDirectly_ThenProvidesLiveData()
    {
        var service = new ExchangeRateService();

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Request {i}");

            _ = service.GetExchangeRates();
        }

        var expected = """
            Request 1
            Fetched data from remote service
            Request 2
            Fetched data from remote service
            Request 3
            Fetched data from remote service
            
            """;

        Assert.Equal(expected.ReplaceLineEndings(), _stringBuilder.ToString().ReplaceLineEndings());
    }

    [Fact]
    public void GivenDataService_WhenCalledThroughProxy_ThenProvidesCachedData()
    {
        var service = new CachedExchangeRateService();

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Request {i}");

            _ = service.GetExchangeRates();
        }

        var expected = """
            Request 1
            Fetched data from remote service
            Request 2
            Read data from cache
            Request 3
            Read data from cache
            
            """;

        Assert.Equal(expected.ReplaceLineEndings(), _stringBuilder.ToString().ReplaceLineEndings());
    }
}