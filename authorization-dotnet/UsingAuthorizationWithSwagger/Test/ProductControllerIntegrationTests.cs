using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Test.Helpers;
using UsingAuthorizationWithSwagger.Models;
using Xunit;

namespace Test
{
    public class ProductControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {

        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _factory;
        public ProductControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }


        [Fact]
        public async Task GetAllProducts_WithoutBearerHeader_ReturnsUnauthorized()
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "wrongToken");

            var response = await _httpClient.GetAsync("api/product");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetAllProducts_WithBearerHeader_ReturnsOk()
        {
            var token = await GetToken("johndoe", "johndoe2410");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("api/product");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAllProducts_WhenExecuted_ReturnsListOfProducts()
        {
            var token = await GetToken("johndoe", "johndoe2410");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("api/product");
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
           
            Assert.IsAssignableFrom<IEnumerable<Product>>(products);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetAProduct_WithExistingId_ReturnsOkAndAProduct(int id)
        {
            var response = await _httpClient.GetAsync($"/api/product/{id}");

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.IsType<Product>(product);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public async Task GetAProduct_WithNonExistingId_ReturnsNotFound(int id)
        {
            var response = await _httpClient.GetAsync($"api/product/{id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }



        private async Task<string> GetToken(string userName, string password)
        {
            var request = new
            {
                Url = "/api/auth",
                Body = new
                {
                    UserName = userName,
                    Password = password
                }
            };
            // Act
            var res = await _httpClient.PostAsync(request.Url, HelperClass.ContentHelper.GetStringContent(request.Body));

            if (!res.IsSuccessStatusCode) return null;

            var userModel = await res.Content.ReadAsStringAsync();
            if (userModel is null) return null;

            return JsonConvert.DeserializeObject<Tokeen>(userModel).Token;
            //  return userModel;
        }
    }
}
