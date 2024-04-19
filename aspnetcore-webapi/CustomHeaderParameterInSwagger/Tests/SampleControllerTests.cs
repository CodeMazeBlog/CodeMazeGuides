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
    public void Get_ValidHeader_ReturnsOk()
    {
        _httpContext.Request.Headers["X-Custom-Header"] = "secret-key";

        var result = _controller.Get();

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void Get_InvalidHeader_ReturnsUnauthorized()
    {
        _httpContext.Request.Headers["X-Custom-Header"] = "invalid-key";

        var result = _controller.Get();

        Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
    }

    [TestMethod]
    public void Post_ValidHeader_ReturnsOk()
    {
        _httpContext.Request.Headers["X-Custom-Header"] = "secret-key";

        var result = _controller.Post();

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void Post_EmptyHeader_ReturnsUnauthorized()
    {
        _httpContext.Request.Headers["X-Custom-Header"] = "";

        var result = _controller.Post();

        Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
    }

    [TestMethod]
    public void Post_NoHeader_ReturnsUnauthorized()
    {
        var result = _controller.Post();

        Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
    }
}