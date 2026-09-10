using Microsoft.AspNetCore.Mvc.Testing;
using OptionalParameterinWebApi;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class ProductControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        private readonly WebApplicationFactory<Program> _factory;

        public ProductControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_WhenExecuted_ReturnsListOfProducts()
        {
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/Product");

            Assert.IsAssignableFrom<IEnumerable<Product>>(products);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(6)]
        public async Task GetById_WithInt_ReturnsProduct(int id)
        {
            var allProducts = (await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/Product"))!.ToList();
            var product = await _httpClient.GetFromJsonAsync<Product>($"/api/Product/GetById/{id}");

            var correspondingProduct = allProducts.FirstOrDefault(x => x.Id == id);

            Assert.NotNull(product);
            Assert.Equal(correspondingProduct?.Name, product.Name);
        }

        // The article is about what happens when the segment is left out entirely, and
        // no test covered it. "{id:int?}" makes the URL match without the segment, and
        // the action's own default of 1 is what decides which product comes back.
        [Fact]
        public async Task GetById_WhenIdOmitted_ReturnsDefaultProduct()
        {
            var response = await _httpClient.GetAsync("/api/Product/GetById");
            var product = await response.Content.ReadFromJsonAsync<Product>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(product);
            Assert.Equal(1, product.Id);
            Assert.Equal("Sweater", product.Name);
        }

        // The two GetBy actions share the "GetBy" literal and are told apart by the
        // "int" constraint on the second one. Overlapping templates are the classic
        // AmbiguousMatchException shape, so the disambiguation is asserted, not assumed.
        [Fact]
        public async Task GetBy_WithName_ReturnsProductMatchedByName()
        {
            var product = await _httpClient.GetFromJsonAsync<Product>("/api/Product/GetBy/Boots");

            Assert.NotNull(product);
            Assert.Equal("Boots", product.Name);
            Assert.Equal(5, product.Id);
        }

        [Fact]
        public async Task GetBy_WithInt_ReturnsProductMatchedById()
        {
            var product = await _httpClient.GetFromJsonAsync<Product>("/api/Product/GetBy/5");

            Assert.NotNull(product);
            Assert.Equal(5, product.Id);
            Assert.Equal("Boots", product.Name);
        }
    }
}
