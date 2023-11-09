using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using OptionalParameterinWebApi;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class ProductControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient;
        private readonly WebApplicationFactory<Program> _factory;

        public ProductControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_WhenExecuted_ReturnsListOfProducts()
        {
            var response = await _httpClient.GetAsync("api/Product");
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

            Assert.IsAssignableFrom<IEnumerable<Product>>(products);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetBy_WithInt_ReturnsProduct(int id)
        {
            var allProductsResponse = await _httpClient.GetAsync("api/Product");
            var response = await _httpClient.GetAsync($"/api/Product/GetById/{id}");

            var allProductsContent = await allProductsResponse.Content.ReadAsStringAsync();
            var content = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(allProductsContent).ToList();
            var product = JsonConvert.DeserializeObject<Product>(content);

            var correspondingProduct = products.FirstOrDefault(x => x.Id == id);


            Assert.IsType<Product>(product);
            Assert.Equal(correspondingProduct?.Name, product.Name);
        }
             

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public async Task GetById_WithInt_ReturnsProduct(int id)
        {
            var allProductsResponse = await _httpClient.GetAsync("api/Product");
            var response = await _httpClient.GetAsync($"/api/Product/GetById/{id}");

            var allProductsContent = await allProductsResponse.Content.ReadAsStringAsync();
            var content = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(allProductsContent).ToList();
            var product = JsonConvert.DeserializeObject<Product>(content);

            var correspondingProduct = products.FirstOrDefault(x => x.Id == id);

            Assert.IsType<Product>(product);
            Assert.Equal(correspondingProduct?.Name, product.Name);
        }
    }
}