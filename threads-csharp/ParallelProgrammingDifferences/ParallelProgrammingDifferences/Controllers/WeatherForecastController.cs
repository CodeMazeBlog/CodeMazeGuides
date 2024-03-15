using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace ParallelProgrammingDifferences.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController() : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    ];

    [HttpGet("weather-forecast-parallel", Name = "GetWeatherForecastParallelForEachAsync")]
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastParallelForEachAsync()
    {
        Console.WriteLine($"GetWeatherForecastParallelForEachAsync started on thread: {Environment.CurrentManagedThreadId}");

        ParallelOptions parallelOptions = new()
        {
            MaxDegreeOfParallelism = 3
        };

        var resultBag = new ConcurrentBag<IEnumerable<WeatherForecast>>();

        await Parallel.ForEachAsync(Enumerable.Range(0, 3), parallelOptions, async (index, _) =>
        {
            var result = await AsyncMethod();
            resultBag.Add(result);
        });

        Console.WriteLine($"GetWeatherForecastParallelForEachAsync completed on thread: {Environment.CurrentManagedThreadId}");

        return resultBag.SelectMany(cr => cr);
    }

    [HttpGet("weather-forecast-when-all", Name = "GetWeatherForecastWhenAll")]
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastWhenAll()
    {
        Console.WriteLine($"GetWeatherForecastWhenAll started on thread: {Environment.CurrentManagedThreadId}");

        var tasks = new List<Task<IEnumerable<WeatherForecast>>>();

        var result1 = Task.Run(() => AsyncMethod());
        var result2 = Task.Run(() => AsyncMethod());
        var result3 = Task.Run(() => AsyncMethod());

        tasks.Add(result1);
        tasks.Add(result2);
        tasks.Add(result3);

        var combinedResults = await Task.WhenAll(tasks);
        var result = combinedResults.SelectMany(cr => cr);

        Console.WriteLine($"GetWeatherForecastWhenAll completed on thread: {Environment.CurrentManagedThreadId}");

        return result;
    }


    private static async Task<IEnumerable<WeatherForecast>> AsyncMethod()
    {
        Console.WriteLine($"AsyncMethod started on thread: {Environment.CurrentManagedThreadId}");
       
        await Task.Delay(250);

        Console.WriteLine($"AsyncMethod completed on thread: {Environment.CurrentManagedThreadId}");

        return Enumerable.Range(6, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = new Random().Next(-20, 55),
            Summary = Summaries[new Random().Next(Summaries.Length)]
        })
        .ToArray();
    }
}
