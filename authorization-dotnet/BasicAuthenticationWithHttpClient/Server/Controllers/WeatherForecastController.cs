using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (IsRequestAuthenticated())
            {
                return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }));
            }
            
            return Unauthorized();            
        }

        private bool IsRequestAuthenticated()
        {
            try
            {
                if (AuthenticationHeaderValue.TryParse(Request.Headers.Authorization, out var basicAuthCredential))
                {
                    if (basicAuthCredential.Scheme == "Basic" &&
                        !string.IsNullOrWhiteSpace(basicAuthCredential.Parameter))
                    {
                        var usernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(basicAuthCredential.Parameter));
                        if (!string.IsNullOrWhiteSpace(usernamePassword))
                        {
                            var separatorIndex = usernamePassword.IndexOf(':');

                            var username = usernamePassword[..separatorIndex];
                            var password = usernamePassword[(separatorIndex + 1)..];

                            if (username == "codemaze" &&
                                password == "isthebest")
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch
            {
            }

            return false;
        }
    }
}