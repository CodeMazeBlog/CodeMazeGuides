using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Server;

namespace Tests;

public class ServerUnitTest
{
    [Fact]
    public void GivenAnAuthenticatedRequest_WhenGetIsCalled_ThenAnOkResultIsReturnedWithWeatherDetails()
    {
        // Arrange
        var logger = new Mock<ILogger<Server.Controllers.WeatherForecastController>>();        
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers["Authorization"] = "Basic Y29kZW1hemU6aXN0aGViZXN0";
        var controller = new Server.Controllers.WeatherForecastController(logger.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            }
        };

        // Act
        var result = controller.Get() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result.Value);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("Basic wrong-cred")]
    public void GivenARequestWithAnInvalidAuthorizationHeader_WhenGetIsCalled_ThenAnUnauthorizedResultIsReturned(string authorizationHeader)
    {
        // Arrange
        var logger = new Mock<ILogger<Server.Controllers.WeatherForecastController>>();
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers["Authorization"] = authorizationHeader;
        var controller = new Server.Controllers.WeatherForecastController(logger.Object)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            }
        };

        // Act
        var result = controller.Get() as UnauthorizedResult;

        // Assert
        Assert.NotNull(result);
    }
}