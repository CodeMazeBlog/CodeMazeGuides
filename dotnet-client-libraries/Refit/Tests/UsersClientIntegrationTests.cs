using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using RefitLibrary;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests;

public class UsersClientIntegrationTests
{
    private readonly IUsersClient _usersClient;

    public UsersClientIntegrationTests()
    {
        _usersClient = RestService.For<IUsersClient>("https://jsonplaceholder.typicode.com/");
    }

    [Fact]
    public async Task GivenUsersClient_WhenGettingUsers_ThenReturnsListOfUsers()
    {
        // Act
        var users = await _usersClient.GetAll();

        // Assert
        Assert.NotNull(users);
    }

    [Fact]
    public async Task GivenUsersClient_WhenGettingUser_ThenReturnsUserWithSpecifiedId()
    {
        // Act
        var user = await _usersClient.GetUser(1);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(1, user.Id);
    }

    [Fact]
    public async Task GivenUsersClient_WhenCreatingUser_ThenReturnsUserWithNewId()
    {
        // Arrange
        var user = new User
        {
            Name = "Test user",
            Email = "test.user@test.com"
        };

        // Act
        var createdUser = await _usersClient.CreateUser(user);

        // Assert
        Assert.NotNull(createdUser);
        Assert.True(createdUser.Id > 0);
    }

    [Fact]
    public async Task GivenUsersClient_WhenUpdatingUser_ThenReturnsUpdatedUser()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Name = "Test user",
            Email = "test.user@test.com"
        };

        // Act
        var updatedUser = await _usersClient.UpdateUser(user.Id, user);

        // Assert
        Assert.NotNull(updatedUser);
        Assert.Equal(user.ToString(), updatedUser.ToString());
    }
}
