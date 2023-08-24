using DynamicallyCreateClass.WithExpando;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class WeatherWithExpandoUnitTest
{
    [TestMethod]
    public void GivenDataFromManySources_WhenAggregated_ThenGetAverage()
    {
        WeatherSource ws1 = new WeatherSource(1, 10.5, 40);
        WeatherSource ws2 = new WeatherSource(2, 10.0, 45);
        WeatherSource ws3 = new WeatherSource(3, 9.5, 35);

        var weatherAggregator = new WeatherAggregator(
            ws1.WeatherObject,
            ws2.WeatherObject,
            ws3.WeatherObject
        );

        Assert.AreEqual(10.0, weatherAggregator.AggregatedWeather.Temperature);
        Assert.AreEqual(40, weatherAggregator.AggregatedWeather.Humidity);
    }

    [TestMethod]
    public void GivenDataFromManySources_WhenChangeTemperature_ThenAverageChangesToo()
    {
        WeatherSource ws1 = new WeatherSource(1, 10.7, 40);
        WeatherSource ws2 = new WeatherSource(2, 10.0, 45);
        WeatherSource ws3 = new WeatherSource(3, 9.0, 35);

        var weatherAggregator = new WeatherAggregator(
            ws1.WeatherObject,
            ws2.WeatherObject,
            ws3.WeatherObject
        );
        weatherAggregator.RoundWeatherDataForSource1();

        Assert.AreEqual(10.0, weatherAggregator.AggregatedWeather.Temperature);
        Assert.AreEqual(40, weatherAggregator.AggregatedWeather.Humidity);
    }

    [TestMethod]
    public void GivenAnExpandoObject_WhenConvertedToCsv_ThenReturnCsv()
    {
        WeatherSource ws1 = new WeatherSource(1, 10.7, 40);

        var csvResult = ws1.WeatherObject.Format();

        Assert.AreEqual("10.7,40", csvResult);
    }
}
