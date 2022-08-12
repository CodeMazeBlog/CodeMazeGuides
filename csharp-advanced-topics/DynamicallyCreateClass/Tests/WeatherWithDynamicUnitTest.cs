using System.Text.Json.Nodes;
using DynamicallyCreateClass.WithDynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class WeatherWithDynamicUnitTest
{
    [TestMethod]
    public void GivenDataFromManySources_WhenAggregated_ThenGetAverage()
    {
        WeatherSource ws1 = new WeatherSource(1, 10.5, 40);
        WeatherSource ws2 = new WeatherSource(2, 10.0, 45);
        WeatherSource ws3 = new WeatherSource(3, 9.5, 35);

        var weatherAggregator = new WeatherAggregator(
            new WeatherData[] { ws1.WeatherObject, ws2.WeatherObject, ws3.WeatherObject }
        );

        Assert.AreEqual(10.0, weatherAggregator.AggregatedWeather.Temperature);
        Assert.AreEqual(40, weatherAggregator.AggregatedWeather.Humidity);
    }

    [TestMethod]
    public void GivenADynamicObject_WhenGetMember_ThenReturnIt()
    {
        dynamic weatherObj = new WeatherSource(1, 10.7, 40).WeatherObject;

        var temperature = weatherObj.Temperature1;

        Assert.AreEqual(10.7, (double)temperature);
    }

    [TestMethod]
    public void GivenADynamicObject_WhenSetMember_ThenValueIsChanged()
    {
        dynamic weatherObj = new WeatherSource(1, 10.7, 40).WeatherObject;

        weatherObj.Temperature1 = 10;

        Assert.IsTrue(weatherObj.Temperature1.GetType().IsAssignableTo(typeof(JsonValue)));
        Assert.AreEqual(10, (int)weatherObj.Temperature1);
    }

    [TestMethod]
    public void GivenADynamicObject_WhenConvertedToCsv_ThenReturnCsv()
    {
        dynamic weatherObj = new WeatherSource(1, 10.7, 40).WeatherObject;

        var csvResult = weatherObj.Format();

        Assert.AreEqual("10.7,40", csvResult);
    }

    [TestMethod]
    public void GivenADynamicObject_WhenCastingItExplicitly_ThenReturnWeatherData()
    {
        dynamic weatherObj = new WeatherSource(1, 10.7, 40).WeatherObject;

        var weatherData = (WeatherData)weatherObj;

        Assert.AreEqual(10.7, weatherData.Temperature);
        Assert.AreEqual(40, weatherData.Humidity);
    }

    [TestMethod]
    public void GivenADynamicObject_WhenCastingItImplicitly_ThenReturnWeatherData()
    {
        dynamic weatherObj = new WeatherSource(1, 10.7, 40).WeatherObject;

        WeatherData weatherData = weatherObj;

        Assert.AreEqual(10.7, weatherData.Temperature);
        Assert.AreEqual(40, weatherData.Humidity);
    }
}
