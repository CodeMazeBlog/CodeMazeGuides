using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Net;

namespace RemoteHostIpAddress.Controllers
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

        [HttpGet(Name = "GetWeatherForecastData")]
        public IEnumerable<WeatherForecast> Get()
        {
            var remoteIpAddress = GetRemoteHostIpAddressUsingRemoteIpAddress();
            Console.WriteLine(remoteIpAddress);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
        }

        public IPAddress GetRemoteHostIpAddressUsingRemoteIpAddress()
        {
            return HttpContext.Connection.RemoteIpAddress;
        }

        public IPAddress? GetRemoteHostIpAddressUsingXForwardedFor()
        {
            IPAddress? remoteIpAddress = null;
            var forwardedFor = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            if (!string.IsNullOrEmpty(forwardedFor))
            {
                var ips = forwardedFor.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(s => s.Trim());

                foreach (var ip in ips)
                {
                    if (IPAddress.TryParse(ip, out var address) &&
                        (address.AddressFamily == AddressFamily.InterNetwork || address.AddressFamily == AddressFamily.InterNetworkV6))
                    {
                        remoteIpAddress = address;
                        break;
                    }
                }
            }

            return remoteIpAddress;
        }

        public IPAddress? GetRemoteHostIpAddressUsingXRealIp()
        {
            IPAddress? remoteIpAddress = null;

            if (HttpContext.Request.Headers.TryGetValue("X-Real-IP", out var xRealIp) &&
                IPAddress.TryParse(xRealIp, out var realIp) &&
                (realIp.AddressFamily == AddressFamily.InterNetwork || realIp.AddressFamily == AddressFamily.InterNetworkV6))
            {
                remoteIpAddress = realIp;
            }

            return remoteIpAddress;
        }
    }
}