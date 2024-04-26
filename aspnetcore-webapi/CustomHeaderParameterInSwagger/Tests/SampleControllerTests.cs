namespace GlobalHeaderParameterInSwagger.Tests;

[TestClass]
public class SampleControllerTests
{
    private SampleController _controller;
    private DefaultHttpContext _httpContext;

    [TestInitialize]
    public void Initialize()
    {
        _httpContext = new DefaultHttpContext();
        _controller = new SampleController
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = _httpContext
            }
        };
    }

    [TestMethod]
    public void GivenGetRequestWithCustomHeader_WhenValidHeader_ThenReturnsOk()
    {
        _httpContext.Request.Headers["X-Custom-Header"] = "secret-key";

        var result = _controller.Get();

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void GivenGetRequestWithCustomHeader_WhenInvalidHeader_ThenReturnsUnauthorized()
    {
        _httpContext.Request.Headers["X-Custom-Header"] = "invalid-key";

        var result = _controller.Get();

        Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
    }

    [TestMethod]
    public void GivenPostRequestWithCustomHeader_WhenValidHeader_ThenReturnsOk()
    {
        _httpContext.Request.Headers["X-Custom-Header"] = "secret-key";

        var result = _controller.Post();

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void GivenPostRequestWithCustomHeader_WhenEmptyHeader_ThenReturnsUnauthorized()
    {
        _httpContext.Request.Headers["X-Custom-Header"] = "";

        var result = _controller.Post();

        Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
    }

    [TestMethod]
    public void GivenPostRequestWithCustomHeader_WhenNoHeader_ThenReturnsUnauthorized()
    {
        var result = _controller.Post();

        Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
    }
}