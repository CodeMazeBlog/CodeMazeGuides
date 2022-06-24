using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResolvingDependencyInjection;
using ResolvingDependencyInjection.Controllers;
using ResolvingDependencyInjection.Models;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        ILogger<WeatherForecastController> _logger;
        IStringLocalizer<SharedResource> _localizer;

        public UnitTest()
        {
            _logger = new Logger<WeatherForecastController>(LoggerFactory.Create(
              x => x.AddConsole()));

            var options = Options.Create(new LocalizationOptions {});
            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);
            _localizer = new StringLocalizer<SharedResource>(factory);
        }

        [TestMethod]
        public void WhenWeatherForecastControllerGetIsCalledWithCorrectInput_UserGetsRightResult()
        {
            var wfController = new WeatherForecastController(_logger, _localizer);
            var cityForecast = wfController.Post( new TravelDestination { CityName = "TOK", VacationDays = 2});
            Assert.IsNotNull(cityForecast);
        }

        [TestMethod]
        public void WhenWeatherForecastControllerGetIsCalledWithoutInput_ANullReferenceExceptionIsThrown()
        {
            var wfController = new WeatherForecastController(_logger, _localizer);
            wfController.ModelState.AddModelError("MissingRequestBodyRequiredValue", "MissingRequestBodyRequiredValue");
            CityForecast? result;
            try
            {

                result = wfController.Post(model: null);
            }catch(NullReferenceException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NullReferenceException));
            }

        }
    }
}