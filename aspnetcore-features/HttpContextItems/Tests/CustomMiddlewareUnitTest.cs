using HttpContextItems_API;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests
{
    public class CustomMiddlewareUnitTest
    {
        [Fact]
        public async Task WhenExecuting_ShouldSetMiddlewareObjectKey()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CustomMiddleware>>();
            var logger = loggerMock.Object;
            var context = new DefaultHttpContext();
            var requestDelegate = new RequestDelegate(context => Task.CompletedTask);
            var middleware = new CustomMiddleware(requestDelegate);

            // Act
            await middleware.Invoke(context);

            // Assert
            Assert.True(context.Items.ContainsKey(CustomMiddleware.MiddlewareObjectKey));
            Assert.Equal("Weather Forecast", context.Items[CustomMiddleware.MiddlewareObjectKey]);
        }
    }
}
