using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace SwashbuckleVsNSwagTests
{
    public class BuiltInOpenApiTests
    {
        private WebApplicationFactory<Program> _factory = null!;
        private HttpClient _client = null!;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task WhenRequestingTheJsonDocument_ThenItDescribesTheApi()
        {
            var response = await _client.GetAsync("/openapi/v1.json");
            var body = await response.Content.ReadAsStringAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(body, Does.Contain("\"openapi\""));
            Assert.That(body, Does.Contain("/Customer"));
        }

        [Test]
        public async Task WhenRequestingTheYamlDocument_ThenItIsServed()
        {
            var response = await _client.GetAsync("/openapi/v1.yaml");
            var body = await response.Content.ReadAsStringAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(body, Does.StartWith("openapi:"));
        }

        [Test]
        public async Task WhenRequestingSwaggerUi_ThenThePageIsServed()
        {
            var response = await _client.GetAsync("/swagger/index.html");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
