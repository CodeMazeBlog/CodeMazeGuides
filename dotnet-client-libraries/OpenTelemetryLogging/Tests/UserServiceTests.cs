using Microsoft.Extensions.Logging;
using Moq;
using OpenTelemetryLogging;

namespace Tests;

public class UserServiceTests
{
    private readonly ILogger<UserService> _logger;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _logger = Mock.Of<ILogger<UserService>>();
        _userService = new UserService(_logger);
    }

    [Fact]
    public void GivenValidUser_WhenLoggingIn_ReturnsTrue()
    {
        // Arrange
        var user = new User("codemaze", "Pa$$w0rd!!");

        // Act
        var result = _userService.Login(user.UserName, user.Password);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GivenInvalidUser_WhenLoggingIn_ReturnsFalse()
    {
        // Arrange
        var user = new User("codemaze", "Pa$$w0rd");

        // Act
        var result = _userService.Login(user.UserName, user.Password);

        // Assert
        Assert.False(result);
    }
}