using Microsoft.AspNetCore.Mvc.Testing;
using PublishVsSendInMediatR.Commands;
using PublishVsSendInMediatR.Events;
using System.Net;
using System.Net.Http.Json;

namespace PublishVsSendInMediatRTests
{
    public class UserControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public UserControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async Task WhenCreateANewUser_ThenReturnCreatedStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/api/users", new CreateUserCommand { Email = "sample@sample.com", UserName = "SampleUser" });
            var idUserCreated = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.True(int.Parse(idUserCreated) > 0);
        }

        [Fact]
        public async Task WhenUserCreatedNotify_ThenReturnOkStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/api/users/notify", new UserCreatedEvent { UserId = 1, UserName = "SampleUser" });

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}