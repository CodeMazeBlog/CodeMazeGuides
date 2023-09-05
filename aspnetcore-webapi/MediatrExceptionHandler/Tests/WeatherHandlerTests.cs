using MediatrExceptionHandler.Handlers;
using MediatrExceptionHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Tests
{
    public class WeatherHandlerTests
    {
        [Fact]
        public async Task WhenCallingWeatherHandler_ThenNotImplementedExceptionIsThrownAsync()
        {
            // Arrange
            var handler = new GetWeatherHandler();

            // Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => handler
                .Handle(new MediatrExceptionHandler.Requests.GetWeatherRequest(), CancellationToken.None));
        }
    }
}