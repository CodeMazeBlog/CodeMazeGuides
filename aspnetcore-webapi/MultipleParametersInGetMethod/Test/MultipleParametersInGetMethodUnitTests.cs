using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultipleParametersInGetMethod;
using MultipleParametersInGetMethod.Models;
using Newtonsoft.Json;
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
            List<ProductDto>? expectedProducts = new List<ProductDto>()
            {
                new ProductDto{ Id = 1, Category = "Electronic", Brand = "Sony", Name = "Play Station", WarrantyYears = 2, IsAvailable = true },
                new ProductDto{ Id = 2, Category = "Electronic", Brand = "Sony", Name = "Mobile", WarrantyYears = 2, IsAvailable = true }
            };

            //Act
            HttpResponseMessage? response = await _client.GetAsync("api/Product?category=Electronic&brand=Sony");
            string? content = await response.Content.ReadAsStringAsync();
            List<ProductDto>? products = JsonConvert.DeserializeObject<List<ProductDto>>(content);

            //Assert
            Assert.IsNotNull(products);
            foreach (var product in products)
            {
                Assert.AreEqual(expectedProducts.FirstOrDefault(x => x.Id == product.Id)?.Id, product.Id);
            }
        }

        [TestMethod]
        public async Task GivenARequestWithRouteParams_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            // Arrange
            string expectedCategory = "Electronic";

            //Act
            HttpResponseMessage? response = await _client.GetAsync("api/Product/2");
            string? content = await response.Content.ReadAsStringAsync();
            ProductDto? product = JsonConvert.DeserializeObject<ProductDto>(content);

            //Assert
            Assert.IsNotNull(product);
            Assert.AreEqual(expectedCategory, product.Category);
        }

        [TestMethod]
        public async Task GivenARequestWithBody_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            // Arrange
            ProductDto productDto = new()
            {
                Category = "Sports",
            };

            List<ProductDto>? expectedProducts = new List<ProductDto>()
            {
                new ProductDto{ Id = 5, Category = "Sports", Brand = "Nike", Name = "Sneakers", WarrantyYears = 3, IsAvailable = false },
                new ProductDto{ Id = 6, Category = "Sports", Brand = "Adidas", Name = "Football", WarrantyYears = 3, IsAvailable = false }
            };

            string? json = JsonConvert.SerializeObject(productDto);

            HttpRequestMessage? request = new HttpRequestMessage(HttpMethod.Get, "api/Product/category")
            {
                Content = new StringContent(json, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json)
            };


            //Act
            HttpResponseMessage? response = await _client.SendAsync(request);
            string? content = await response.Content.ReadAsStringAsync();

            List<ProductDto>? products = JsonConvert.DeserializeObject<List<ProductDto>>(content);

            //Assert
            Assert.IsNotNull(products);
            foreach (var product in products)
            {
                Assert.AreEqual(expectedProducts.FirstOrDefault(x => x.Id == product.Id)?.Id, product.Id);
            }
        }

        [TestMethod]
        public async Task GivenARequestWithRouteAndQueryParams_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            //Arrange
            List<ProductDto>? expectedProducts = new List<ProductDto>()
            {
                new ProductDto{ Id = 1, Category = "Electronic", Brand = "Sony", Name = "Play Station", WarrantyYears = 2, IsAvailable = true },
                new ProductDto{ Id = 2, Category = "Electronic", Brand = "Sony", Name = "Mobile", WarrantyYears = 2, IsAvailable = true },
            };

            //Act
            HttpResponseMessage? response = await _client.GetAsync("api/Product/brand/Sony/warranty?waranty=2");
            string? content = await response.Content.ReadAsStringAsync();

            List<ProductDto>? products = JsonConvert.DeserializeObject<List<ProductDto>>(content);

            //Assert
            Assert.IsNotNull(products);
            foreach (var product in products)
            {
                Assert.AreEqual(expectedProducts.FirstOrDefault(x => x.Id == product.Id)?.Name, product.Name);
            }
        }

        [TestMethod]
        public async Task GivenARequest_WhenGetProductIsCalled_ThenReturnMatchingProduct()
        {
            //Arrange
            string productName = "Mobile";
            bool isProductAvailable = true;
            List<ProductDto>? expectedProducts = new List<ProductDto>()
            {
                new ProductDto{ Id = 2, Category = "Electronic", Brand = "Sony", Name = "Mobile", WarrantyYears = 2, IsAvailable = true },
                new ProductDto{ Id = 7, Category = "Electronic", Brand = "Apple", Name = "Mobile", WarrantyYears = 2, IsAvailable = true }
            };

            //Act
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Product/v1/filter");
            request.Headers.Add("name", productName);
            request.Headers.Add("isAvailable", isProductAvailable.ToString());

            var response = await _client.SendAsync(request);
            string? content = await response.Content.ReadAsStringAsync();

            List<ProductDto>? products = JsonConvert.DeserializeObject<List<ProductDto>>(content);

            //Assert
            Assert.IsNotNull(products);
            foreach (var product in products)
            {
                Assert.AreEqual(expectedProducts.FirstOrDefault(x => x.Brand == product.Brand)?.Id, product.Id);
            }
        }
    }
}