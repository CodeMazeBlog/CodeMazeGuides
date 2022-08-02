using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResolvingDependencyInjection.Controllers;
using ResolvingDependencyInjection.Models;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        ILogger<WeatherForecastController> _logger;

        public UnitTest()
        {
            _logger = new Logger<WeatherForecastController>(LoggerFactory.Create(
              x => x.AddConsole()));
        }

        [TestMethod]
        public void WhenWeatherForecastControllerGetIsCalledWithCorrectInput_ThenUserGetsRightResult()
        {
            var wfController = new WeatherForecastController(_logger);
            var cityForecast = wfController.Post( new TravelDestination { CityName = "TOK", VacationDays = 2});
            Assert.IsNotNull(cityForecast);
        }

        [TestMethod]
        public void WhenWeatherForecastControllerGetIsCalledWithoutInput_ThenANullReferenceExceptionIsThrown()
        {
            var wfController = new WeatherForecastController(_logger);
            CityForecast? result;
            try
            {
                result = wfController.Post(model: null);
            }
            catch(NullReferenceException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NullReferenceException));
            }

        }
    }
}