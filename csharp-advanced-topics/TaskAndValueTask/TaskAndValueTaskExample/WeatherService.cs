namespace TaskAndValueTaskExample;

using System.Collections.Concurrent;

public class WeatherService
{
    private readonly ConcurrentDictionary<string, Weather> _cache;

    public WeatherService()
    {
        _cache = new();
    }

    public async Task<Weather> GetWeatherTask(string city)
    {
        if (!_cache.ContainsKey(city))
        {
            var weather = await DummyWeatherProvider.Get(city);
            _cache.TryAdd(city, weather);
        }

        return _cache[city];
    }

    public async ValueTask<Weather> GetWeatherValueTask(string city)
    {
        if (!_cache.ContainsKey(city))
        {
            var weather = await DummyWeatherProvider.Get(city);
            _cache.TryAdd(city, weather);
        }

        return _cache[city];   
    }
}