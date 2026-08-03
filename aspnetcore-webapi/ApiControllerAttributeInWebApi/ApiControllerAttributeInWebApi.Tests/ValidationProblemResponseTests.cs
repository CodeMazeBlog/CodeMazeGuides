using ApiControllerAttributeInWebApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace ApiControllerAttributeInWebApi.Tests
{
    public class ValidationProblemResponseTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ValidationProblemResponseTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task WhenUsingApiController_ThenChecksModelStateAutomatically()
        {
            // arrange
            var client = _factory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(new Customer()), Encoding.UTF8, MediaTypeNames.Application.Json);

            // act
            var response = await client.PostAsync("/customers", content);
            
            // assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task WhenCustomizedResponse_ThenFormatApplies()
        {
            // arrange
            var client = _factory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(new Customer()), Encoding.UTF8, MediaTypeNames.Application.Json);

            // act
            var response = await client.PostAsync("/customers", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            // assert
            using (var jsonDocument = JsonDocument.Parse(responseBody))
            {
                var root = jsonDocument.RootElement;
                var errors = root.GetProperty("errors").EnumerateArray();

                Assert.Equal("/customers", root.GetProperty("path").GetString());
                Assert.Equal("POST", root.GetProperty("method").GetString());
                Assert.Equal("Customers", root.GetProperty("controller").GetString());
                Assert.Equal("PostCustomer", root.GetProperty("action").GetString());
                Assert.Equal("Name", errors.First().GetProperty("field").GetString());
                Assert.Equal("The Name field is required.", errors.First().GetProperty("messages").EnumerateArray().First().GetString());
            }
        }

        [Fact]
        public async Task WhenCustomValidations_ThenReturnsValidationProblem()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync("/customers/17");
            var responseBody = await response.Content.ReadAsStringAsync();

            // assert
            using (var jsonDocument = JsonDocument.Parse(responseBody))
            {
                var root = jsonDocument.RootElement;

                Assert.Equal("https://tools.ietf.org/html/rfc7231#section-6.5.1", root.GetProperty("type").GetString());
                Assert.Equal("One or more validation errors occurred.", root.GetProperty("title").GetString());
                Assert.Equal(400, root.GetProperty("status").GetInt32());
            }
        }

    }
}