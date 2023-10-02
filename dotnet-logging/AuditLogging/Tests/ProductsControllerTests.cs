using AuditLogApp.Controllers;
using AuditLogApp.Data;
using AuditLogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;


namespace Tests;

public class ProductsControllerTests
{
    [Fact]
    public void GivenGetProducts_WhenNoProductsFound_ThenReturnNotFound()
    {
        // Arrange
        var mockContext = new Mock<ProductsDbContext>();

        mockContext.Setup(c => c.Products).Returns((DbSet<Product>)null);
        var controller = new ProductsController(mockContext.Object);

        // Act
        var result = controller.GetProduct().Result.Result;

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void GivenGetProducts_WhenProductsFound_ThenReturnProducts()
    {
        // Arrange
        var mockContext = new Mock<ProductsDbContext>();

        var products = GetProducts();

        mockContext.Setup(c => c.Products).ReturnsDbSet(products);
        var controller = new ProductsController(mockContext.Object);

        // Act
        var productsResult = controller.GetProduct().Result.Value;

        // Assert 
        Assert.IsType<List<Product>>(productsResult);
        Assert.Equal(2, productsResult.Count());
    }

    [Fact]
    public void GivenGetProduct_WhenProductFound_ThenReturnOkResult()
    {
        // Arrange
        var mockContext = new Mock<ProductsDbContext>();

        var products = GetProducts();

        mockContext.Setup(c => c.Products.FindAsync(1).Result)
            .Returns(products.Find(e => e.Id == 1));

        var controller = new ProductsController(mockContext.Object);

        // Act
        var productResult = controller.GetProduct(1).Result.Result as OkObjectResult;

        // Assert 
        Assert.Equal(200, productResult.StatusCode);
    }

    [Fact]
    public void GivenGetProduct_WhenProductNotFound_ThenReturnNotFound()
    {
        // Arrange
        var mockContext = new Mock<ProductsDbContext>();

        var products = GetProducts();

        mockContext.Setup(c => c.Products.FindAsync(1).Result)
            .Returns(products.Find(e => e.Id == 1));

        var controller = new ProductsController(mockContext.Object);

        // Act
        var productResult = controller.GetProduct(3).Result.Result as NotFoundResult;

        // Assert 
        Assert.Equal(404, productResult.StatusCode);
    }

    [Fact]
    public void GivenPostProduct_WhenProductCreated_ThenReturnCreatedResult()
    {
        // Arrange
        var mockContext = new Mock<ProductsDbContext>();

        var products = GetProducts();

        mockContext.Setup(c => c.Products.Add(It.IsAny<Product>()))
            .Callback<Product>((s) => products.Add(s));

        var controller = new ProductsController(mockContext.Object);

        // Act
        var productResult = controller.PostProduct(new Product { Id = 3, Name = "Product 3", Price = 3.45m }).Result.Result as CreatedAtActionResult;

        // Assert 
        Assert.Equal(201, productResult.StatusCode);
    }

    [Fact]
    public void GivenPostProduct_WhenProductCreated_ThenVerifyItIsAdded()
    {
        // Arrange
        var mockContext = new Mock<ProductsDbContext>();

        var products = GetProducts();

        mockContext.Setup(c => c.Products.Add(It.IsAny<Product>()))
            .Callback<Product>((s) => products.Add(s));

        var controller = new ProductsController(mockContext.Object);

        // Act
        var productResult = controller.PostProduct(new Product { Id = 3, Name = "Product 3", Price = 3.45m }).Result.Result as CreatedAtActionResult;

        // Assert 
        Assert.Equal(3, products.Count);
        Assert.Equal(201, productResult.StatusCode);
    }

    [Fact]
    public void GivenDeleteProduct_WhenProductDeleted_ReturnNoContentResult()
    {
        // Arrange
        var mockContext = new Mock<ProductsDbContext>();

        var products = GetProducts();

        mockContext.Setup(c => c.Products.FindAsync(1).Result)
            .Returns(products.Find(e => e.Id == 1));

        mockContext.Setup(c => c.Products.Remove(It.IsAny<Product>()))
            .Callback<Product>((s) => products.Remove(s));

        var controller = new ProductsController(mockContext.Object);

        // Act
        var productResult = controller.DeleteProduct(1).Result as NoContentResult;

        // Assert 
        Assert.Equal(204, productResult.StatusCode);
    }

    [Fact]
    public void GivenDeleteProduct_WhenProductDeleted_ThenVerifyItIsRemoved()
    {
        // Arrange
        var mockContext = new Mock<ProductsDbContext>();

        var products = GetProducts();

        mockContext.Setup(c => c.Products.FindAsync(1).Result)
            .Returns(products.Find(e => e.Id == 1));

        mockContext.Setup(c => c.Products.Remove(It.IsAny<Product>()))
            .Callback<Product>((s) => products.Remove(s));

        var controller = new ProductsController(mockContext.Object);

        // Act
        var productResult = controller.DeleteProduct(1).Result as NoContentResult;

        // Assert 
        Assert.Single(products);
        Assert.Equal(204, productResult.StatusCode);
    }

    private static List<Product> GetProducts()
    {
        return new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 1.23m },
            new Product { Id = 2, Name = "Product 2", Price = 2.34m }
        };
    }
}