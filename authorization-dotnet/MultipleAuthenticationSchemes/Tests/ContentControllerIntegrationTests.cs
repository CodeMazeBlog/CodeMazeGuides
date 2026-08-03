using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;

namespace Tests
{
    public class ContentControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _factory;

        public ContentControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task GivenLoggedInUserWithCookie_WhenGetWithCookie_ThenResultIsOk()
        {
            // Given
            var responseCookie = await _httpClient.PostAsync("/auth/loginCookie",
            Helpers.ContentHelper.GetStringContent(new
            {
                Username = "Author with cookie scheme",
            }));

            var cookie = responseCookie.Headers.GetValues("Set-Cookie").FirstOrDefault()!.Split("=")[1];

            _httpClient.DefaultRequestHeaders.Add(".AspNetCore.Cookies", cookie);

            // When
            var response = await _httpClient.GetAsync("/content/getWithCookie");

            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GivenLoggedInUserWithToken_WhenGetWithCookie_ThenResultIs401()
        {
            // Given
            var loginJwtResponse = await _httpClient.PostAsync("/auth/loginDefaultJwt",
                Helpers.ContentHelper.GetStringContent(new
                {
                    Username = "Author with default jwt scheme",
                }));

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(loginJwtResponse));

            // When
            var response = await _httpClient.GetAsync("/content/getWithCookie");

            // Then
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
