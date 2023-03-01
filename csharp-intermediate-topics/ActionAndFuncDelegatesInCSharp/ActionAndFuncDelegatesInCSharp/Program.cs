using ActionAndFuncDelegatesInCSharp;

string city = "New York";
WeatherService weatherService = new WeatherService();

Action<string> displayWeatherAction = (weatherData) =>
{
    Console.WriteLine("Current weather in " + city + ": " + weatherData);
};

Func<string, string> formatWeatherFunc = (rawWeatherData) =>
{
    string[] weatherParts = rawWeatherData.Split(new char[] { ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
    var temperature = Convert.ToInt32(weatherParts[1].Trim());
    var humidity = Convert.ToInt32(weatherParts[3].Trim());
    return "Temperature: " + (temperature - 273) + "C, Humidity: " + humidity + "%";
};

weatherService.GetWeather(city, displayWeatherAction, formatWeatherFunc);