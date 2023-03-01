// See https://aka.ms/new-console-template for more information
using ActionAndFuncDelegatesInCSharp;

static void Print(string strValue)
{
    Console.WriteLine(strValue);
}
static int Sum(int x, int y)
{
    return x + y;
}

//Delegates for print and sum functions examples
Action<string> printAction = new Action<string>(Print);
printAction("Action and Func Delegates");

Func<int, int, int> printFunc = new Func<int, int, int>(Sum);
Console.WriteLine(printFunc(1, 2));

//Delegates for weather application example
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
