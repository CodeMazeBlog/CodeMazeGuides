using FixUnableToResolveServiceIssue.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace FixUnableToResolveServiceIssue.Tests.Services
{
    public class ServiceResolutionTest
    {
        private WebApplicationFactory<Program> _factory = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _factory.Dispose();
        }

        [Test]
        public void WhenSmtpSettingsAreBoundToOptions_EmailServiceResolvesWithConfiguredValues()
        {
            //Arrange
            using var scope = _factory.Services.CreateScope();

            //Act
            var emailService = scope.ServiceProvider.GetRequiredService<EmailService>();

            //Assert
            Assert.That(emailService.GetServerAddress(), Is.EqualTo("smtp.example.com:587"));
        }

        [Test]
        public void WhenAddHttpClientIsRegistered_HttpClientTypesResolve()
        {
            //Arrange
            using var scope = _factory.Services.CreateScope();
            var provider = scope.ServiceProvider;

            //Act
            var httpClientFactory = provider.GetService<IHttpClientFactory>();
            var httpClient = provider.GetService<HttpClient>();
            var weatherClient = provider.GetService<WeatherClient>();

            //Assert
            Assert.That(httpClientFactory, Is.Not.Null);
            Assert.That(httpClient, Is.Not.Null);
            Assert.That(weatherClient, Is.Not.Null);
            Assert.That(httpClientFactory!.CreateClient(nameof(WeatherClient)).BaseAddress,
                Is.EqualTo(new Uri("https://api.example.com/")));
        }
    }
}
