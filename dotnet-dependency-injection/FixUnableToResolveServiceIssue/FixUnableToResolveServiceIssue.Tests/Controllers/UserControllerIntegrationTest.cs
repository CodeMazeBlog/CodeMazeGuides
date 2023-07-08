using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FixUnableToResolveServiceIssue.Models;

namespace FixUnableToResolveServiceIssue.Tests.Controllers
{
    internal class UserControllerIntegrationTest : BaseIntegrationTest
    {
        [Test]
        public async Task WhenInvokingGet_ReturnsStatusCode500()
        {
            //Arrange
            const int expectedId = 1;
            const string expectedFirstName = "Code";
            const string expectedLastName = "Maze";

            //Act
            var response = await httpClient.GetAsync("/api/User");
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
