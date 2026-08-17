using CqrsAndMediatRInAspNetCore;
using CqrsAndMediatRInAspNetCore.Commands;
using CqrsAndMediatRInAspNetCore.DataStore;
using CqrsAndMediatRInAspNetCore.Handlers;
using CqrsAndMediatRInAspNetCore.Notifications;
using CqrsAndMediatRInAspNetCore.Queries;

namespace CqrsAndMediatRInAspNetCoreTests;

public class ProductHandlersTests
{
    private static FakeDataStore NewSeededStore() => new();

    [Fact]
    public async Task WhenHandleGetProductsQuery_ThenReturnsAllSeededProducts()
    {
        var handler = new GetProductsHandler(NewSeededStore());

        var result = await handler.Handle(new GetProductsQuery(), CancellationToken.None);

        Assert.Equal(3, result.Count());
    }

    [Fact]
    public async Task WhenHandleGetProductByIdQuery_ThenReturnsMatchingProduct()
    {
        var handler = new GetProductByIdHandler(NewSeededStore());

        var result = await handler.Handle(new GetProductByIdQuery(2), CancellationToken.None);

        Assert.Equal(2, result.Id);
        Assert.Equal("Test Product 2", result.Name);
    }

    [Fact]
    public async Task WhenHandleAddProductCommand_ThenProductIsPersistedAndReturned()
    {
        var store = NewSeededStore();
        var addHandler = new AddProductHandler(store);
        var newProduct = new Product { Id = 4, Name = "Test Product 4" };

        var returned = await addHandler.Handle(new AddProductCommand(newProduct), CancellationToken.None);

        Assert.Equal(newProduct, returned);
        var all = await new GetProductsHandler(store).Handle(new GetProductsQuery(), CancellationToken.None);
        Assert.Contains(all, p => p.Id == 4 && p.Name == "Test Product 4");
    }

    [Fact]
    public async Task WhenEmailHandlerHandlesNotification_ThenProductRecordsTheEvent()
    {
        var store = NewSeededStore();
        var handler = new EmailHandler(store);
        var product = new Product { Id = 1, Name = "Test Product 1" };

        await handler.Handle(new ProductAddedNotification(product), CancellationToken.None);

        var stored = await store.GetProductById(1);
        Assert.Equal("Test Product 1 evt: Email sent", stored.Name);
    }

    [Fact]
    public async Task WhenCacheInvalidationHandlerHandlesNotification_ThenProductRecordsTheEvent()
    {
        var store = NewSeededStore();
        var handler = new CacheInvalidationHandler(store);
        var product = new Product { Id = 3, Name = "Test Product 3" };

        await handler.Handle(new ProductAddedNotification(product), CancellationToken.None);

        var stored = await store.GetProductById(3);
        Assert.Equal("Test Product 3 evt: Cache Invalidated", stored.Name);
    }
}
