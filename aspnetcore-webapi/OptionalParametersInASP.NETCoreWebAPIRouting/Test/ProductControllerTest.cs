using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OptionalParametersInASP.NETCoreWebAPIRouting;
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
            var response = await _httpClient.GetAsync($"/api/Product/GetBy/{id}");

            var allProductsContent = await allProductsResponse.Content.ReadAsStringAsync();
            var content = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(allProductsContent).ToList();
            var product = JsonConvert.DeserializeObject<Product>(content);

            var correspondingProduct = products.FirstOrDefault(x => x.Id == id);


            Assert.IsType<Product>(product);
            Assert.Equal(correspondingProduct?.Name, product.Name);
        }

        [Theory]
        [InlineData("Schoolbag")]
        [InlineData("Sunshade")]
        public async Task GetBy_WithString_ReturnsProduct(string name)
        {
            var allProductsResponse = await _httpClient.GetAsync("api/Product");
            var response = await _httpClient.GetAsync($"/api/Product/GetBy/{name}");

            var allProductsContent = await allProductsResponse.Content.ReadAsStringAsync();
            var content = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(allProductsContent).ToList();
            var product = JsonConvert.DeserializeObject<Product>(content);

            var correspondingProduct = products.FirstOrDefault(x => x.Name == name);

            Assert.Equal(correspondingProduct?.Name, product.Name);
            Assert.IsType<Product>(product);
        }


        [Theory]
        [InlineData(1, "Sweater")]
        [InlineData(2, "Umbrella")]
        public async Task GetBy_WithIntOrString_ReturnsSameProduct(int id, string name)
        {           
            var stringResponse = await _httpClient.GetAsync($"/api/Product/GetBy/{name}");
            var intResponse = await _httpClient.GetAsync($"/api/Product/GetBy/{id}");

            var stringContent = await stringResponse.Content.ReadAsStringAsync();
            var intContent = await intResponse.Content.ReadAsStringAsync();

            var stringProduct = JsonConvert.DeserializeObject<Product>(stringContent);
            var intProduct = JsonConvert.DeserializeObject<Product>(intContent);            

            Assert.Equal(stringProduct.Name, intProduct.Name);            
        }

        [Fact]
        public async Task GetById_WithoutOptionalParameter_ReturnsFirstProduct()
        {
            var response = await _httpClient.GetAsync($"/api/Product/GetById");
            var allProductsResponse = await _httpClient.GetAsync("api/Product");            

            var allProductsContent = await allProductsResponse.Content.ReadAsStringAsync();
            var content = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(allProductsContent).ToList();
            var product = JsonConvert.DeserializeObject<Product>(content);

            var correspondingProduct = products.FirstOrDefault();

            Assert.Equal(correspondingProduct?.Name, product.Name);
            Assert.IsType<Product>(product);
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