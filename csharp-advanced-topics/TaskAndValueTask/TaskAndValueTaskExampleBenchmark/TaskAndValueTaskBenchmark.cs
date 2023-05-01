namespace TaskAndValueTaskExampleBenchmark;

using BenchmarkDotNet.Attributes;
using TaskAndValueTaskExample;

[MemoryDiagnoser]
public class TaskAndValueTaskBenchmark
{
    private readonly WeatherService _weatherService;

    public TaskAndValueTaskBenchmark()
    {
        _weatherService = new();
    }
    
    [Benchmark]
    [Arguments("Denver")]
    public async Task<Weather> TaskBenchmark(string city)
    {
        return await _weatherService.GetWeatherTask(city);
    }

    [Benchmark]
    [Arguments("London")]
    public async ValueTask<Weather> ValueTaskBenchmark(string city)
    {
        return await _weatherService.GetWeatherValueTask(city);
    }
}