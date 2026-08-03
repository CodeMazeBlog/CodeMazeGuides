using GlobalDefaultJsonSerializationoptions;
using GlobalDefaultJsonSerializationoptions.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GlobalDefaultJsonSerializationoptionsUnitTests;

[TestClass]
public class ProductControllerUnitTests
{
    private ProductController? _controller;

    [TestInitialize]
    public void SetUp()
    {
        _controller = new ProductController();
    }

    [TestMethod]
    public void GivenValidProduct_WhenCreateProductIsCalled_ThenReturnsProductWithSameDetails()
    {
        var product = new Product { Id = 1, Name = "Test Product", ReleaseDate = DateTime.Now};

        var result = _controller!.CreateProduct(product) as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result.StatusCode);
        Assert.AreEqual(product, result.Value);
    }

    [TestMethod]
    public void GivenValidProduct_WhenSaveProductIsCalled_ThenReturnsProductWithSameDetails()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Test Product", ReleaseDate = DateTime.Now };

        // Act
        var result = _controller!.SaveProduct(product) as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result.StatusCode);

        var expectedJson = JsonConvert.SerializeObject(product);
        Assert.AreEqual(expectedJson, result?.Value?.ToString());
    }
}
