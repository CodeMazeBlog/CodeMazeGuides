namespace ExampleApp;

public static class DummyWeatherProvider
{
    public static async Task<Weather> Get(string city)
    {
        await Task.Delay((int)TimeSpan.FromSeconds(5).TotalMilliseconds);
        var weather = new Weather 
        { 
            City = city, 
            Date = DateTime.Now, 
            AvgTempratureF = new Random().Next(5, 70) 
        };
        
        return weather;
    }
}