using HttpContextItems_API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests
{
    public class CustomFilterUnitTest
    {
        [Fact]
        public void WhenActionExecuting_ThenSetFilterObjectKey()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CustomFilter>>();
            var logger = loggerMock.Object;
            var filter = new CustomFilter(logger);
            var context = new ActionExecutingContext(
                new ActionContext(new DefaultHttpContext(),
                new Microsoft.AspNetCore.Routing.RouteData(),
                new ControllerActionDescriptor()),
                Array.Empty<IFilterMetadata>(),
                new Dictionary<string, object>(),
                new Mock<Controller>().Object
            );

            // Act
            filter.OnActionExecuting(context);

            // Assert
            Assert.True(context.HttpContext.Items.ContainsKey(CustomFilter.FilterObjectKey));
            Assert.Equal("Please wait...", context.HttpContext.Items[CustomFilter.FilterObjectKey]);
        }

        [Fact]
        public void WhenActionExecuted_ThenSetFilterObjectKey()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CustomFilter>>();
            var logger = loggerMock.Object;
            var filter = new CustomFilter(logger);
            var context = new ActionExecutedContext(
                new ActionContext(new DefaultHttpContext(),
                new Microsoft.AspNetCore.Routing.RouteData(),
                new ControllerActionDescriptor()),
                Array.Empty<IFilterMetadata>(),
                new Mock<Controller>().Object
            );

            // Act
            filter.OnActionExecuted(context);

            // Assert
            Assert.True(context.HttpContext.Items.ContainsKey(CustomFilter.FilterObjectKey));
            Assert.Equal("The forecast is ready", context.HttpContext.Items[CustomFilter.FilterObjectKey]);
        }
    }
}
