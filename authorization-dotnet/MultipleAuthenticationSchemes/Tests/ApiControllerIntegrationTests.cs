using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Headers;

namespace Tests
{
    public class ApiControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _factory;

        public ApiControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task GivenLoggedInUserWithDefaultJwt_WhenGetWithAny_ThenResultIsOK()
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
            var response = await _httpClient.GetAsync("/api/getWithAny");

            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GivenLoggedInUserWithSecondJwt_WhenGetWithSecondJwt_ThenResultIsOK()
        {
            // Given
            var loginJwtResponse = await _httpClient.PostAsync("/auth/loginSecondJwt",
                Helpers.ContentHelper.GetStringContent(new
                {
                    Username = "Author with second jwt scheme",
                }));

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await Helpers.GetToken(loginJwtResponse));

            // When
            var response = await _httpClient.GetAsync("/api/getWithSecondJwt");

            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GivenLoggedInUserWithDefaultJwt_WhenGetWithSecondJwt_ThenResultIs401()
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
            var response = await _httpClient.GetAsync("/api/getWithSecondJwt");

            // Then
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
