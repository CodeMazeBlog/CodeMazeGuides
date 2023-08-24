using System.Collections.Generic;
using UsingAuthorizationWithSwagger.Data;
using UsingAuthorizationWithSwagger.Models;
using Xunit;

namespace Test
{
    public class ProductStoreUnitTests
    {
        [Fact]
        public void GetProducts_WhenExecuted_ReturnsListOfProducts()
        {
            var products = ProductStore.GetProducts();

            Assert.IsAssignableFrom<IEnumerable<Product>>(products);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetProduct_WithExistingId_ReturnsAProduct(int id)
        {
            var product = ProductStore.GetProduct(id);

            Assert.NotNull(product);
            Assert.Equal(id, product?.Id);
            Assert.IsAssignableFrom<Product>(product);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void GetAProduct_WithNonExistingId_ReturnsNull(int id)
        {
            var product = ProductStore.GetProduct(id);

            Assert.Null(product);
        }
    }
}
