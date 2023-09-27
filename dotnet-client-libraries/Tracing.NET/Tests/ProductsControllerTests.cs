using MockQueryable.Moq;
using Moq;
using System.Diagnostics;
using Tracing.NET.Controllers;
using Tracing.NET.Data;

namespace Tests;

public class ProductsControllerTests
{
    private readonly ProductsController _controller;
    private readonly Mock<ProductsDataContext> _mockDataContext;
    private List<Product> _products = new();

    public ProductsControllerTests()
    {
        _products.Add(new Product
        {
            Id = 1,
            Name = "Test Name",
            Description = "Test description",
            Price = 1m
        });
        var productListMock = _products.AsQueryable().BuildMockDbSet();
        _mockDataContext = new Mock<ProductsDataContext>();
        _mockDataContext.Setup(x => x.Products).Returns(productListMock.Object);
        _controller = new ProductsController(_mockDataContext.Object);
    }

    [Fact]
    public async void GivenInitialRequest_WhenGetProductsCalled_ChecksCacheForProducts()
    {
        // Arrange
        var activitiesStarted = SetupActivityListener();

        // Act
        var result = await _controller.GetProducts();

        // Assert
        Assert.NotNull(result);
        Assert.Single(activitiesStarted);
        Assert.Contains("CheckCache", activitiesStarted.Select(a => a.DisplayName));
    }

    [Fact]
    public async void GivenSecondRequest_WhenGetProductsCalled_ReturnsProductsFromCache()
    {
        // Arrange
        var activitiesStarted = SetupActivityListener();

        // Act
        var initialRequest = await _controller.GetProducts();
        var secondRequest = await _controller.GetProducts();

        // Assert
        Assert.Equal(2, activitiesStarted.Count);
        Assert.Contains("CheckCache", activitiesStarted.Select(a => a.DisplayName));

        var events = activitiesStarted.SelectMany(a => a.Events);
        Assert.Contains("ProductsRetrievedFromCache", events.Select(e => e.Name));
    }

    private static List<Activity> SetupActivityListener()
    {
        var activitiesStarted = new List<Activity>();
        var activityListener = new ActivityListener
        {
            ShouldListenTo = s => true,
            SampleUsingParentId = (ref ActivityCreationOptions<string> activityOptions) => ActivitySamplingResult.AllData,
            Sample = (ref ActivityCreationOptions<ActivityContext> activityOptions) => ActivitySamplingResult.AllData,
            ActivityStarted = activitiesStarted.Add
        };
        ActivitySource.AddActivityListener(activityListener);
        return activitiesStarted;
    }
}