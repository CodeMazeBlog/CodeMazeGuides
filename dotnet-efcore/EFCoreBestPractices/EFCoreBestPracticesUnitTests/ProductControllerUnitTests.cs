using EFCoreBestPractices;
using EFCoreBestPractices.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCoreBestPracticesUnitTests;

[TestClass]
public class ProductControllerUnitTests
{
    private ProductController? _controller;
    private ApplicationDbContext? _context;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase(databaseName: "TestDatabase")
                      .Options;

        _context = new ApplicationDbContext(options);

        _controller = new ProductController(_context);
    }

    [TestMethod]
    public async Task GivenValidProducts_WhenGetProductDataUsingProjection_ThenReturnsCorrectData()
    {
        var result = await _controller!.GetProductDataUsingProjection() as OkObjectResult;

        Assert.IsNotNull(result);
        var products = result.Value as IEnumerable<object>;
        Assert.AreEqual(3, products?.Count());
    }

    [TestMethod]
    public async Task GivenProductsWithPrice_WhenGetProductDataByFilteringEarly_ThenReturnsFilteredProducts()
    {
        var result = await _controller!.GetProductDataByFilteringEarly() as OkObjectResult;

        Assert.IsNotNull(result);
        var products = result.Value as IEnumerable<object>;
        Assert.AreEqual(3, products?.Count());
    }

    [TestMethod]
    public async Task GivenNewProducts_WhenPostProductDataUsingBatch_ThenAddsNewProducts()
    {
        var result = await _controller!.PostProductDataUsingBatch();

        Assert.IsInstanceOfType(result, typeof(OkResult));
        var allProducts = await _context!.Products.ToListAsync();
        Assert.AreEqual(5, allProducts.Count);
    }

    [TestMethod]
    public async Task GivenValidProductId_WhenGetProductDataUsingAsNoTracking_ThenReturnsProduct()
    {
        var result = await _controller!.GetProductDataUsingAsNoTracking(1) as OkObjectResult;

        Assert.IsNotNull(result);
        var product = result.Value as Product;
        Assert.IsNotNull(product);
        Assert.AreEqual(1, product.Id);
    }

    [TestMethod]
    public async Task GivenValidPageNumber_WhenGetProductDataUsingSkipTake_ThenReturnsPagedProducts()
    {
        var result = await _controller!.GetProductDataUsingSkipTake() as OkObjectResult;

        Assert.IsNotNull(result);
        var products = result.Value as IEnumerable<object>;
        Assert.AreEqual(3, products?.Count());
    }

    [TestMethod]
    public async Task GivenOrdersWithSuppliers_WhenGetCategoriesUsingEagerLoading_ThenReturnsCategoriesWithOrders()
    {
        var result = await _controller!.GetCategoriesUsingEagerLoading() as OkObjectResult;

        Assert.IsNotNull(result);
        var categories = result.Value as IEnumerable<object>;
        Assert.IsTrue(categories?.Any());
    }

    [TestMethod]
    public void GivenProductsAbovePrice_WhenGetProductDataUsingCompiledQuery_ThenReturnsExpensiveProducts()
    {
        var result = _controller!.GetProductDataUsingCompiledQuery() as OkObjectResult;

        Assert.IsNotNull(result);
        var products = result.Value as IEnumerable<object>;
        Assert.AreEqual(2, products?.Count());
    }

    [TestMethod]
    public async Task GivenNewProducts_WhenPostProductDataUsingAsyncCalls_ThenAddsNewProductsAsync()
    {
        var result = await _controller!.PostProductDataUsingAsyncCalls();

        Assert.IsInstanceOfType(result, typeof(OkResult));
        var allProducts = await _context!.Products.ToListAsync();
        Assert.AreEqual(5, allProducts.Count);
    }

    [TestMethod]
    public async Task GivenValidSearchCriteria_WhenGetProductsDataByPreventingSqlInjection_ThenReturnsFilteredProducts()
    {
        var result = await _controller!.GetProductsDataByPreventingSqlInjection(1, "Product 1") as OkObjectResult;

        Assert.IsNotNull(result);
        var products = result.Value as IEnumerable<object>;
        Assert.AreEqual(1, products?.Count());
    }

    [TestCleanup]
    public void Cleanup()
    {
        _context!.Database.EnsureDeleted();
        _context.Dispose();
    }
}
