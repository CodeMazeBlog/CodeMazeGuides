using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Test.Helpers;
using Xunit;

namespace Test
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
        public async Task Login_WithValidCredentials_ReturnsOk()
        {
            var request = new
            {
                Url = "/api/auth",
                Body = new                {
                    UserName = "johndoe",
                    Password = "johndoe2410"
                }
            };

            // Act
            var response = await _httpClient.PostAsync(request.Url, HelperClass.ContentHelper.GetStringContent(request.Body));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Login_WithInValidCredentials_ReturnsUnauthorized()
        {
            //Assert
            var request = new
            {
                Url = "/api/auth",
                Body = new
                {
                    UserName = "anythingelse",
                    Password = "anythingelse2410"
                }
            };
            // Act
            var response = await _httpClient.PostAsync(request.Url, HelperClass.ContentHelper.GetStringContent(request.Body));

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }       
    }
}
