using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using ReadingRequestBody.Controllers;
using ReadingRequestBody.Utils;
using System.Text;

namespace Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private IFixture _fixture;
        private Mock<ILogger> _loggerMock;

        [TestInitialize]
        public void Setup()
        {
            _fixture = new Fixture();
            _loggerMock = new Mock<ILogger>();
        }

        [TestMethod]
        public void WhenIndexActionCalled_ThenResponseMustBeReturn()
        {
            var controller = GetControllerInstance(string.Empty);
            var result = controller.Index();

            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
            Assert.AreEqual((result as OkObjectResult).Value, "Web API is ready.");
        }

        [TestMethod]
        public async Task WhenReadAsStringActionCalled_ThenResponseMustBeReturn()
        {
            var bodyString = _fixture.Create<string>();
            var controller = GetControllerInstance(bodyString);
            var result = await controller.ReadAsString();

            TestRequest(result, "Request Body As String:", bodyString);
        }

        [TestMethod]
        public async Task WhenReadAsStringActionCalled_WithEmptyBody_ThenResponseMustBeReturn()
        {
            var bodyString = string.Empty;
            var controller = GetControllerInstance(bodyString);
            var result = await controller.ReadAsString();

            TestRequest(result, "Request Body As String:", bodyString);
        }

        [TestMethod]
        public async Task WhenReadFromAttributeActionCalled_ThenResponseMustBeReturn()
        {
            var bodyString = _fixture.Create<string>();
            var controller = GetControllerInstance(bodyString);

            var context = new ActionExecutingContext(
                new ActionContext
                {
                    HttpContext = controller.ControllerContext.HttpContext,
                    RouteData = controller.ControllerContext.RouteData,
                    ActionDescriptor = controller.ControllerContext.ActionDescriptor
                },
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                controller);

            var attribute = new ReadRequestBodyAttribute();
            await attribute.OnActionExecutionAsync(context, () => Task.FromResult<ActionExecutedContext>(null));

            var result = controller.ReadFromAttribute();

            TestRequest(result, "Request Body From Attribute :", bodyString);
        }

        [TestMethod]
        public async Task WhenCustomMiddlewareCalled_ThenRequestBodyMiddlewareHeaderMustBePresent()
        {
            var bodyString = _fixture.Create<string>();
            var middleware = new RequestBodyMiddleware(next: (innerHttpContext) =>
            {
                return Task.CompletedTask;
            }, _loggerMock.Object);

            var context = new DefaultHttpContext();
            context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(bodyString));
            context.Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(bodyString));
            context.Request.Path = new PathString("/home/read-from-middleware");

            await middleware.Invoke(context);

            var body = new StreamReader(context.Response.Body).ReadToEnd();

            Assert.AreEqual(bodyString, body);
            Assert.IsTrue(context.Request.Headers.ContainsKey("RequestBodyMiddleware"));
        }

        [TestMethod]
        public async Task WhenCustomMiddlewareCalled_WithInvalidRequestPath_ThenRequestBodyMiddlewareHeaderMustNotBePresent()
        {
            var bodyString = _fixture.Create<string>();
            var requestPath = _fixture.Create<string>();
            var middleware = new RequestBodyMiddleware(next: (innerHttpContext) =>
            {
                return Task.CompletedTask;
            }, _loggerMock.Object);

            var context = new DefaultHttpContext();
            context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(bodyString));
            context.Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(bodyString));
            context.Request.Path = new PathString("/home/" + requestPath);

            await middleware.Invoke(context);

            var body = new StreamReader(context.Response.Body).ReadToEnd();

            Assert.AreEqual(bodyString, body);
            Assert.IsFalse(context.Request.Headers.ContainsKey("RequestBodyMiddleware"));
        }

        [TestMethod]
        public async Task WhenReadFromActionFilterActionCalled_ThenResponseMustBeReturn()
        {
            var bodyString = _fixture.Create<string>();
            var controller = GetControllerInstance(bodyString);
            controller.HttpContext.Request.Path = "/home/read-from-action-filter";

            var actionContext = new ActionContext(controller.HttpContext,
                new RouteData(),
                new ActionDescriptor(),
                new ModelStateDictionary());
            var actionExecutingContext = new ActionExecutingContext(actionContext, new List<IFilterMetadata>(), new Dictionary<string, object>(), controller: controller);

            Task<ActionExecutedContext> next()
            {
                var ctx = new ActionExecutedContext(actionContext, new List<IFilterMetadata>(), controller);
                return Task.FromResult(ctx);
            }

            var actionFilter = new ReadRequestBodyActionFilter();
            await actionFilter.OnActionExecutionAsync(actionExecutingContext, next);

            var result = controller.ReadFromActionFilter();

            TestRequest(result, "Request Body From Action Filter :", bodyString);
        }

        private static void TestRequest(IActionResult result, string responsePrefix, string bodyString)
        {
            var resultValue = result != null ? (result as OkObjectResult).Value : string.Empty;

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
            Assert.AreEqual(resultValue, $"{responsePrefix} {bodyString}");
        }

        private static HomeController GetControllerInstance(string bodyString)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(bodyString));
            var httpContext = new DefaultHttpContext()
            {
                Request = { Body = stream, ContentLength = stream.Length, RouteValues = new RouteValueDictionary() }
            };

            var controllerContext = new ControllerContext
            {
                HttpContext = httpContext,
                RouteData = new RouteData(),
                ActionDescriptor = new ControllerActionDescriptor()
            };

            var controller = new HomeController() { ControllerContext = controllerContext };

            return controller;
        }
    }
}