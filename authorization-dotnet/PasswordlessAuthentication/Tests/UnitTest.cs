using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Logging;
using PasswordlessAuthentication.Controllers;
using Microsoft.AspNetCore.Identity;
using PasswordlessAuthentication.Models;

namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        ILogger<WeatherForecastController> _logger;
        UserManager<IdentityUser> _userManager;
        LoginModel testUser = new LoginModel { UserName = "sally", Email = "sally@example.com" };

        public UnitTest()
        {
            _logger = new Logger<WeatherForecastController>(LoggerFactory.Create(
              x => x.AddConsole()));
            _userManager = new TestUserManager();
        }

        [TestMethod]
        public void WhenWeatherForecastControllerGetIsCalled_UserGetsRightResult()
        {
            var wfController = new WeatherForecastController(_logger);
            var authenticatedResult = wfController.Get();
            Assert.IsNotNull(authenticatedResult);
        }

    }
}
