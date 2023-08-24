namespace Tests;

using TaskAndValueTaskExample;

public class WeatherServiceTests
{
    private readonly WeatherService _weatherService;
    
    public WeatherServiceTests()
    {
        _weatherService = new();
    }

    [Theory]
    [InlineData("London")]
    public async Task GivenCityName_WhenGetWeatherTaskIsInvoked_NonNullWeatherObjectIsReturned(string city)
    {
        var weather = await _weatherService.GetWeatherTask(city);

        Assert.NotNull(weather);
    }

    [Theory]
    [InlineData("Angola")]
    public async Task GivenCityName_WhenGetWeatherTaskIsInvokedConsecutively_CachedWeatherValueIsReturned(string city)
    {
        var weather1 = await _weatherService.GetWeatherTask(city);
        var weather2 = await _weatherService.GetWeatherTask(city);

        Assert.Equal(weather1, weather2);
    }

    [Theory]
    [InlineData("Amsterdam")]
    public async Task GivenCityName_WhenGetWeatherValueTaskIsInvoked_NonNullWeatherObjectIsReturned(string city)
    {
        var weather = await _weatherService.GetWeatherValueTask(city);

        Assert.NotNull(weather);
    }

    [Theory]
    [InlineData("Barcelona")]
    public async Task GivenCityName_WhenGetWeatherValueTaskIsInvokedConsecutively_CachedWeatherValueIsReturned(string city)
    {
        var weather1 = await _weatherService.GetWeatherTask(city);
        var weather2 = await _weatherService.GetWeatherTask(city);

        Assert.Equal(weather1, weather2);
    }
}