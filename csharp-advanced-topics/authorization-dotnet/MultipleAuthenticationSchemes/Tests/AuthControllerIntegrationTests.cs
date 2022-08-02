using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;

namespace Tests
{
    public class AuthControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _factory;

        public AuthControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task WhenLoginDefualtJwt_ThenReturnsOk()
        {
            // When
            var response = await _httpClient.PostAsync("/auth/loginDefaultJwt", 
                Helpers.ContentHelper.GetStringContent(new
                {
                    Username = "Author with default jwt scheme",
                }));

            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenLoginSecondJwt_ThenReturnsOk()
        {
            // When
            var response = await _httpClient.PostAsync("/auth/loginSecondJwt", 
                Helpers.ContentHelper.GetStringContent(new
                {
                    Username = "Author with second jwt scheme",
                }));

            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenLoginCookie_ThenReturnsOk()
        {
            // When
            var response = await _httpClient.PostAsync("/auth/loginCookie", 
                Helpers.ContentHelper.GetStringContent(new
                {
                    Username = "Author with cookie scheme"
                }));

            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}