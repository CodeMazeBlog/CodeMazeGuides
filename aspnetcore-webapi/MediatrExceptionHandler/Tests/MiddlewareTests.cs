using MediatrExceptionHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Tests
{
    public class MiddlewareTests
    {
        [Fact]
        public async Task WhenCatchingException_ThenMiddlewareReturnsInternalServerError()
        {
            // Arrange
            var serviceProvider = new ServiceCollection()
                                    .AddLogging()
                                    .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<GlobalExceptionMiddleware>();

            var expectedExcepton = new ArgumentNullException();
            HttpContext ctx = new DefaultHttpContext();

            RequestDelegate next = (HttpContext hc) => Task.CompletedTask;

            var mw = new GlobalExceptionMiddleware(logger);

            // Act - Part 1: InvokeAsync set-up:
            await mw.InvokeAsync(ctx, null);

            // Assert
            Assert.Equal(HttpStatusCode.InternalServerError, (HttpStatusCode)ctx.Response.StatusCode);
        }
    }
}
