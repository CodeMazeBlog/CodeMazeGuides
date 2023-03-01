namespace ActionAndFuncDelegatesInCSharp
{
    public class WeatherService
    {
        public void GetWeather(string city, Action<string> displayWeatherAction, Func<string, string> formatWeatherFunc)
        {
            string rawWeatherData = "Temp: 293, Humidity: 50";
            string formattedWeatherData = formatWeatherFunc(rawWeatherData);
            displayWeatherAction(formattedWeatherData);
        }
    }
}
