namespace Tests;

using ExampleApp;

public class DummyWeatherProviderTests
{
    [Theory]
    [InlineData("Tokyo")]
    public async Task GivenCityName_WhenGetIsInvoked_RandomWeatherValueIsReturned(string city)
    {
        var weather = await DummyWeatherProvider.Get(city);

        Assert.NotNull(weather);
    }  
}