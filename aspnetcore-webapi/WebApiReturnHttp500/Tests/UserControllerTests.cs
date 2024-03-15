using WebApiReturnHttp500.Interfaces;

namespace Tests;

public class UserControllerTests
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _userServiceMock = new Mock<IUserService>();
        _controller = new UserController(_userServiceMock.Object);
    }

    [Fact]
    public void Given_UserServiceThrowsException_When_GetUsersFirstMethodCalled_Then_InternalServerErrorReturned()
    {
        // Arrange
        _userServiceMock.Setup(u => u.GetAllUsers()).Throws(new Exception("Simulated exception"));

        // Act
        var result = _controller.GetUsersFirstMethod();

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        Assert.Equal("Simulated exception", objectResult.Value);
    }

    [Fact]
    public void Given_UserServiceThrowsException_When_GetUsersSecondMethodCalled_Then_InternalServerErrorStatusCodeReturned()
    {
        // Arrange
        _userServiceMock.Setup(u => u.GetAllUsers()).Throws(new Exception("Simulated exception"));

        // Act
        var result = _controller.GetUsersSecondMethod();

        // Assert
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
        Assert.Equal((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);
    }

    [Fact]
    public void Given_UserServiceThrowsException_When_GetUsersThirdMethodCalled_Then_InternalServerErrorContentReturned()
    {
        // Arrange
        _userServiceMock.Setup(u => u.GetAllUsers()).Throws(new Exception("Simulated exception"));

        // Act
        var result = _controller.GetUsersThirdMethod();

        // Assert
        var contentResult = Assert.IsType<ContentResult>(result);
        Assert.Equal((int)HttpStatusCode.InternalServerError, contentResult.StatusCode);
        Assert.Equal("An error occurred while processing the request.", contentResult.Content);
        Assert.Equal("text/plain", contentResult.ContentType);
    }

    [Fact]
    public void Given_UserServiceThrowsException_When_GetUsersFourthMethodCalled_Then_InternalServerErrorProblemDetailsReturned()
    {
        // Arrange
        _userServiceMock.Setup(u => u.GetAllUsers()).Throws(new Exception("Simulated exception"));

        // Act
        var result = _controller.GetUsersFourthMethod();

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        var problemDetails = Assert.IsType<ProblemDetails>(objectResult.Value);
        Assert.Equal("Internal Server Error", problemDetails.Title);
        Assert.Equal("An error occurred while processing the request.", problemDetails.Detail);
    }
}