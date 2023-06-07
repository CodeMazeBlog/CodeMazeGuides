using GlobalRoutePrefixInAspNetCore.API.Controllers;
using GlobalRoutePrefixInAspNetCore.API.Models;
using Microsoft.AspNetCore.Mvc;

public class ProductsControllerTests
{
    [Fact]
    public void WhenGettingProducts_ThenReturnOkResult()
    {
        // Arrange
        var controller = new ProductsController();

        // Act
        var result = controller.GetProducts();

        // Assert
        Assert.IsType<ActionResult<List<Product>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void WhenGettingProducts_ThenReturnValidProducts()
    {
        // Arrange
        var controller = new ProductsController();

        // Act
        var result = controller.GetProducts();
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var products = Assert.IsAssignableFrom<List<Product>>(okResult.Value);

        // Assert
        Assert.NotNull(products);
        Assert.Equal(2, products.Count);
        Assert.Contains(products, p => p.Id == 1 && p.Name == "The Secret Recipes of Chef Uyi");
        Assert.Contains(products, p => p.Id == 2 && p.Name == "Lenovo Yoga Laptop");
    }
}