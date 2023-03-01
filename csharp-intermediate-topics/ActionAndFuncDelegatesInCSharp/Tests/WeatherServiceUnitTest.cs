using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    public class WeatherServiceUnitTest
    {
        WeatherService weatherService = new WeatherService();

        [Fact]
        public void GivenGetWeatherMethod_WhenCalledWithValidCityAndDisplayWeatherAction_ThenCallsDisplayWeatherAction()
        {
            var city = "New York";
            var isDisplayWeatherActionCalled = false;
            Action<string> displayWeatherAction = (weather) =>
            {
                isDisplayWeatherActionCalled = true;
            };
            Func<string, string> formatWeatherFunc = (rawWeatherData) =>
            {
                return rawWeatherData;
            };

            weatherService.GetWeather(city, displayWeatherAction, formatWeatherFunc);

            Assert.True(isDisplayWeatherActionCalled);
        }

        [Fact]
        public void GivenGetWeatherMethod_WhenCalledWithValidCityAndFormatWeatherFunc_ThenCallsFormatWeatherFunc()
        {
            var city = "New York";
            var isFormatWeatherFuncCalled = false;
            Action<string> displayWeatherAction = (weather) =>
            {
                // Do nothing
            };
            Func<string, string> formatWeatherFunc = (rawWeatherData) =>
            {
                isFormatWeatherFuncCalled = true;
                return rawWeatherData;
            };

            weatherService.GetWeather(city, displayWeatherAction, formatWeatherFunc);

            Assert.True(isFormatWeatherFuncCalled);
        }

        [Fact]
        public void GivenGetWeatherMethod_WhenCalledWithValidCityAndFormattedData_ThenCallsDisplayWeatherActionWithFormattedData()
        {
            var city = "New York";
            var expectedFormattedWeatherData = "Temperature: 70°C, Humidity: 50%";
            Action<string> displayWeatherAction = (weather) =>
            {
                Assert.Equal(expectedFormattedWeatherData, weather);
            };
            Func<string, string> formatWeatherFunc = (rawWeatherData) =>
            {
                return "Temperature: 70°C, Humidity: 50%";
            };

            weatherService.GetWeather(city, displayWeatherAction, formatWeatherFunc);
        }
    }
}