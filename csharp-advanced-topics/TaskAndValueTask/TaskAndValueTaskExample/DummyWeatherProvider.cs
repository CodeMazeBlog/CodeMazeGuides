namespace TaskAndValueTaskExample;

public static class DummyWeatherProvider
{
    public static async Task<Weather> Get(string city)
    {
        await Task.Delay(10);
        var weather = new Weather 
        { 
            City = city, 
            Date = DateTime.Now, 
            AvgTempratureF = new Random().Next(5, 70) 
        };
        
        return weather;
    }
}