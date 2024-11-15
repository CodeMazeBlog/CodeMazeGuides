using APIsUsingSQLite.Controllers;
using APIsUsingSQLite.Data;
using APIsUsingSQLite.Models;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests;

public class ProductsControllerTest
{
    [Fact]
    public void GivenProductsController_WhenGetInvoked_ThenReturnProducts()
    {
        // Arrange
        var products = new Fixture().Build<Product>().CreateMany(1);
        var productContextMock = CreateMockDbContext();
        productContextMock.Setup(x => x.Products)
            .ReturnsDbSet(products);

        // Act
        ProductsController controller = new(productContextMock.Object);
        var result = controller.GetProducts().Value;

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

     [Fact]
    public void GivenProductsController_WhenPostProductInvoked_ThenProductAdded()
    {
        // Arrange
        var product = new Fixture().Build<Product>().Create();
        var productContextMock = CreateMockDbContext();
        var productDbSetMock = new Mock<DbSet<Product>>();
        productContextMock.Setup(x => x.Products)
            .Returns(productDbSetMock.Object);

        // Act
        ProductsController controller = new(productContextMock.Object);
        var productResult = controller.PostProduct(product).Value;

        // Assert
        productDbSetMock.Verify(x => x.Add(It.Is<Product>(y => y == product)), Times.Once);
        productContextMock.Verify(x => x.SaveChanges(), Times.Once);
    }

    private static Mock<ApplicationDbContext> CreateMockDbContext()
    {
        var options = new DbContextOptions<ApplicationDbContext>();
        var productContextMock = new Mock<ApplicationDbContext>(options);
        return productContextMock;
    }
}