using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultipleParametersInGetMethod.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Test
{
    [TestClass]
    public class MultipleParametersInGetMethodUnitTests
    {
        private readonly HttpClient _client;

        public MultipleParametersInGetMethodUnitTests()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }

        [TestMethod]
        public async Task GivenARequestWithQueryParams_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            // Arrange
            var expectedIds = new[] { 1, 2 };

            //Act
            HttpResponseMessage response = await _client.GetAsync("api/Product?category=Electronic&brand=Sony");
            string content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(products);
            Assert.AreEqual(expectedIds.Length, products.Count);
            CollectionAssert.AreEqual(expectedIds, products.Select(x => x.Id).ToArray());
            Assert.IsTrue(products.All(x => x.Category == "Electronic" && x.Brand == "Sony"));
        }

        [TestMethod]
        public async Task GivenARequestUsingFromQueryAttribute_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            // Arrange
            var expectedIds = new[] { 1, 2 };

            //Act
            HttpResponseMessage response = await _client.GetAsync("api/Product/type-manufacturer?type=Electronic&manufacturer=Sony");
            string content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(products);
            Assert.AreEqual(expectedIds.Length, products.Count);
            CollectionAssert.AreEqual(expectedIds, products.Select(x => x.Id).ToArray());
            Assert.IsTrue(products.All(x => x.Category == "Electronic" && x.Brand == "Sony"));
        }

        [TestMethod]
        public async Task GivenARequestWithRouteParams_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            //Act
            HttpResponseMessage response = await _client.GetAsync("api/Product/2");
            string content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(product);
            Assert.AreEqual(2, product.Id);
            Assert.AreEqual("Electronic", product.Category);
            Assert.AreEqual("Sony", product.Brand);
            Assert.AreEqual("Mobile", product.Name);
        }

        [TestMethod]
        public async Task GivenARequestUsingFromRouteAttribute_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            //Act
            HttpResponseMessage response = await _client.GetAsync("api/Product/productId/2");
            string content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(product);
            Assert.AreEqual(2, product.Id);
            Assert.AreEqual("Electronic", product.Category);
            Assert.AreEqual("Sony", product.Brand);
            Assert.AreEqual("Mobile", product.Name);
        }

        [TestMethod]
        public async Task GivenARequestWithBody_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            // Arrange
            var model = new Product { Category = "Sports" };
            var expectedIds = new[] { 5, 6 };

            string json = JsonConvert.SerializeObject(model);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "api/Product/category")
            {
                Content = new StringContent(json, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json)
            };

            //Act
            HttpResponseMessage response = await _client.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(products);
            Assert.AreEqual(expectedIds.Length, products.Count);
            CollectionAssert.AreEqual(expectedIds, products.Select(x => x.Id).ToArray());
            Assert.IsTrue(products.All(x => x.Category == "Sports"));
        }

        [TestMethod]
        public async Task GivenARequestWithRouteAndQueryParams_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            //Arrange
            var expectedIds = new[] { 1, 2 };

            //Act
            HttpResponseMessage response = await _client.GetAsync("api/Product/brand/Sony?warranty=2");
            string content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(products);
            Assert.AreEqual(expectedIds.Length, products.Count);
            CollectionAssert.AreEqual(expectedIds, products.Select(x => x.Id).ToArray());
            Assert.IsTrue(products.All(x => x.Brand == "Sony" && x.WarrantyYears == 2));
        }

        [TestMethod]
        public async Task GivenARequestUsingFromQueryAndFromRouteAttributes_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            //Arrange
            var expectedIds = new[] { 1, 2 };

            //Act
            HttpResponseMessage response = await _client.GetAsync("api/Product/manufacturer/Sony?coverage=2");
            string content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(products);
            Assert.AreEqual(expectedIds.Length, products.Count);
            CollectionAssert.AreEqual(expectedIds, products.Select(x => x.Id).ToArray());
            Assert.IsTrue(products.All(x => x.Brand == "Sony" && x.WarrantyYears == 2));
        }

        [TestMethod]
        public async Task GivenARequestWithHeaderParams_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            //Arrange
            var expectedIds = new[] { 1, 2 };

            //Act
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Product/category-brand");
            request.Headers.Add("category", "Electronic");
            request.Headers.Add("brand", "Sony");

            HttpResponseMessage response = await _client.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(content);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(products);
            Assert.AreEqual(expectedIds.Length, products.Count);
            CollectionAssert.AreEqual(expectedIds, products.Select(x => x.Id).ToArray());
            Assert.IsTrue(products.All(x => x.Category == "Electronic" && x.Brand == "Sony"));
        }
    }
}
