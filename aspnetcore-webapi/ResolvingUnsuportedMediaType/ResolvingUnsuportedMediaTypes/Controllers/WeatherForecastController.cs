using Microsoft.AspNetCore.Mvc;

namespace ResolvingUnsuportedMediaTypes;

[Route("api/[Controller]/[action]")]
public class WeatherForecastController : Controller
{
    public WeatherForecastService _weatherForecastService {get;}
    public WeatherForecastController(WeatherForecastService weatherForecastService)
    {
        weatherForecastService = _weatherForecastService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<WeatherForecast>> GetForecast() {
        return _weatherForecastService.getWeatherForecast();
    }

}
