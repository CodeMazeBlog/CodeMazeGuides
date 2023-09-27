using Client;
using Microsoft.Extensions.Configuration;
using Moq.Protected;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;

namespace Tests;

public class ClientUnitTest
{
    [Fact]
    public async Task GivenARequest_WhenGetIsCalled_ThenAContentResultIsReturned()
    {
        // Arrange
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri == new Uri("https://localhost:7003/weatherforecast") &&
                    req.Headers.Authorization != null &&
                    req.Headers.Authorization.Scheme == "Basic" &&
                    req.Headers.Authorization.Parameter == "Y29kZW1hemU6aXN0aGViZXN0"
                ),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("Mocked response data")
            });

        var httpClient = new HttpClient(handlerMock.Object);

        var configuration = new Mock<IConfiguration>();
        configuration.Setup(x => x["BasicAuthenticationUsername"]).Returns("codemaze");
        configuration.Setup(x => x["BasicAuthenticationPassword"]).Returns("isthebest");

        var weatherForecastClient = new WeatherForecastClient(httpClient, configuration.Object);
        var controller = new Client.Controllers.WeatherForecastController(weatherForecastClient);

        // Act
        var result = await controller.Get() as ContentResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("application/json", result.ContentType);
    }
}