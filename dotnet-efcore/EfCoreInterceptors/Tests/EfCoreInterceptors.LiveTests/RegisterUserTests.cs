using EfCoreInterceptors.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace EfCoreInterceptors.LiveTests;

public class RegisterUserTests : IDisposable
{
    private readonly WebApplicationFactory<Program> _factory = new();

    [Fact]
    public async Task GivenValidUserRequest_WhenSent_ThenUserShouldBeRegisteredAndWelcomeEmailShouldBeSent()
    {
        // Arrange
        var addUserRequest = new AddUserRequest("John Doe", "john.doe@example.com");

        var content = new StringContent(JsonConvert.SerializeObject(addUserRequest), Encoding.UTF8, "application/json");

        var client = _factory.CreateClient();

        // Act
        var response = await client.PostAsync("/register-user", content);

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GivenUserRequestWithoutEmail_WhenSent_ThenTheResultIsInternalServerError()
    {
        // Arrange
        var addUserRequest = new AddUserRequest("Jane Doe", "jane.doe@example.com");

        var content = new StringContent(JsonConvert.SerializeObject(addUserRequest), Encoding.UTF8, "application/json");

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var emailServiceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IEmailService));
                if (emailServiceDescriptor is not null)
                    services.Remove(emailServiceDescriptor);

                services.AddSingleton<IEmailService, MockFailingEmailService>();
            });
        }).CreateClient();

        // Act
        var response = await client.PostAsync("/register-user", content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }

    public void Dispose() => _factory.Dispose();
}