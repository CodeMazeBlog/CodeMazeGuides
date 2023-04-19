using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultipleParametersInGetMethod;
using Newtonsoft.Json;
using System.Text;

namespace Test
{
    [TestClass]
    public class MultipleParametersInGetMethodTests
    {
        private readonly HttpClient _client;

        public MultipleParametersInGetMethodTests()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }

        [TestMethod]
        public async Task GivenARequestWithQueryParams_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            // Arrange
            int expetctedProductId = 1;

            //Act
            var response = await _client.GetAsync("api/Product/query-params?category=Electronic&brand=Sony");
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Product>(content);

            //Assert
            Assert.AreEqual(expetctedProductId, products.Id);
        }

        [TestMethod]
        public async Task GivenARequestWithRouteParams_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            // Arrange
            string expetctedCategory = "Clothing";

            //Act
            var response = await _client.GetAsync("api/Product/route-params/2/Adidas");
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Product>(content);

            //Assert
            Assert.AreEqual(expetctedCategory, products.Category);
        }

        [TestMethod]
        public async Task GivenARequestWithBody_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            // Arrange
            Product product = new Product
            {
                Id = 3,
                Category = "Sports",
                Brand = "Nike"
            };
            var json = JsonConvert.SerializeObject(product);

            var request = new HttpRequestMessage(HttpMethod.Get, "api/Product/request-body");

            request.Content = new StringContent(json, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);

            int expectedProductId = 3;

            //Act
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<Product>(content);

            //Assert
            Assert.IsNotNull(product);
            Assert.IsTrue(products.Id == expectedProductId);
        }

        [TestMethod]
        public async Task GivenARequestWithRouteAndQueryParams_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            //Arrange
            string expectedCategory = "Sports";

            //Act
            var response = await _client.GetAsync("api/Product/route-query-params/3?brand=Nike");
            var content = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<Product>(content);

            //Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(expectedCategory, products.Category);
        }

        [TestMethod]
        public async Task GivenARequest_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            //Arrange
            int expectedProductId = 3;

            //Act
            var response = await _client.GetAsync("api/Product/parameter-binding?category=Sports&brand=Nike&id=3");
            var content = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<Product>(content);

            //Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Id == expectedProductId);
        }
    }
}