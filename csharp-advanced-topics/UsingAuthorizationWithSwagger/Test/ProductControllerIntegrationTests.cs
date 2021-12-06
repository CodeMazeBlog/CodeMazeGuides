using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UsingAuthorizationWithSwagger.Models;
using Xunit;

namespace Test
{
    public class ProductControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>> 
    {
        private readonly WebApplicationFactory<Program> _factory;
        private HttpClient _httpClient = new HttpClient();

        public ProductControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();

        }


        [Fact]
        public async Task GetAllProducts_WhenExecuted_ReturnsOKAndAListOfProducts()
        {
            var response = await _httpClient.GetAsync("api/product");
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
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
    }
}
