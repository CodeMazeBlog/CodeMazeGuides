namespace FixUnableToResolveServiceIssue.Services
{
    public class WeatherClient(HttpClient httpClient)
    {
        public Task<string> GetForecastAsync() => httpClient.GetStringAsync("forecast");
    }
}
