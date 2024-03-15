using System.Net;
using System.Net.Http.Json;
using FixUnableToResolveServiceIssue.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FixUnableToResolveServiceIssue.Tests.Controllers
{
    internal class UserControllerIntegrationTest
    {
        private readonly HttpClient _httpClient;
        
        public UserControllerIntegrationTest()
        {
            var application = new WebApplicationFactory<Program>();
            _httpClient = application.CreateClient();
        }

        [Test]
        public async Task WhenInvokingGet_ReturnsStatusCode200()
        {
            //Arrange
            const int expectedId = 1;
            const string expectedFirstName = "Code";
            const string expectedLastName = "Maze";

            //Act
            var response = await _httpClient.GetAsync("/api/User");
            var responseBody = await response.Content.ReadFromJsonAsync<User>();

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(responseBody, Is.Not.Null);
            Assert.DoesNotThrow(() => response.EnsureSuccessStatusCode());
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseBody?.Id, Is.EqualTo(expectedId));
            Assert.That(responseBody?.FirstName, Is.EqualTo(expectedFirstName));
            Assert.That(responseBody?.LastName, Is.EqualTo(expectedLastName));
        }
    }
}
