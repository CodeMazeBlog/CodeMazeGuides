namespace Tests;

public class ProductTests
{
    [Fact]
    public void GivenProducts_WhenOnGet_ThenReturnAllProducts()
    {
        var productServiceMock = new Mock<IProductService>();
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Headphones", Price = 79.99m, Quantity = 50 },
            new Product { Id = 1, Name = "Fitness Tracker", Price = 59.99m, Quantity = 40 }
        };

        productServiceMock.Setup(x => x.GetProducts()).Returns(products);

        var indexModel = new IndexModel(productServiceMock.Object);

        indexModel.OnGet();

        Assert.NotNull(indexModel.Products);

        Assert.Equal(products, indexModel.Products);
    }

    [Fact]
    public void GivenValidProduct_WhenOnPost_ThenAddProductAndRedirectToIndex()
    {
        var productServiceMock = new Mock<IProductService>();
        var createModel = new CreateModel(productServiceMock.Object);
        createModel.Product = new Product { Id = 1, Name = "Headphones", Price = 79.99m, Quantity = 50 };

        var result = createModel.OnPost();

        Assert.IsType<RedirectToPageResult>(result);

        productServiceMock.Verify(service => service.AddProduct(It.IsAny<Product>()), Times.Once);

        var redirectResult = Assert.IsType<RedirectToPageResult>(result);

        Assert.Equal("/Index", redirectResult.PageName);
    }
}