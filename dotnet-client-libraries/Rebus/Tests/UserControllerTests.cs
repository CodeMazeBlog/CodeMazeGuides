using Microsoft.AspNetCore.Mvc;
using Moq;
using Publisher.Controllers;
using Publisher.Models;
using Rebus.Bus;
using Shared;

namespace Tests;

public class UserControllerTests
{
    private readonly Mock<IBus> _busMock;
    private readonly UsersController _usersController;

    public UserControllerTests()
    {
        _busMock = new Mock<IBus>();
        _usersController = new UsersController(_busMock.Object);
    }

    [Fact]
    public async Task GivenANewUser_WhenCreateUserIsCalled_ThenUserCreatedEventIsPublishedToBus()
    {
        // Arrange
        var user = new User
        {
            Email = "test@test.com",
            Password = "VerySecurePassword"
        };

        // Act
        await _usersController.CreateUser(user);

        // Assert
        _busMock.Verify(b => b.Publish(It.Is<UserCreatedEvent>(u => u.UserName == user.Email), null), Times.Once);
    }

    [Fact]
    public async Task GivenADuplicateUser_WhenCreateUserIsCalled_ThenBadRequestReturned()
    {
        // Arrange
        var user = new User
        {
            Email = "duplicate@test.com",
            Password = "VerySecurePassword"
        };

        // Act
        var newUserResult = await _usersController.CreateUser(user);
        var duplicateUserResult = await _usersController.CreateUser(user);

        // Assert
        Assert.IsType<OkObjectResult>(newUserResult);
        Assert.IsType<BadRequestObjectResult>(duplicateUserResult);
    }
}