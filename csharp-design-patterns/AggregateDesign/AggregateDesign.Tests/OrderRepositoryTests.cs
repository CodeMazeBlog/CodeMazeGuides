using AggregateDesign.Domain;
using AggregateDesign.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace AggregateDesign.Tests;

public sealed class OrderRepositoryTests : IDisposable
{
    private const string DutchOven = "Enameled Cast Iron Covered Dutch Oven";
    private const string Skillet = "Skillet with Red Silicone Hot Handle Holder, 12-inch";

    private readonly SqliteConnection _connection = new("DataSource=:memory:");
    private readonly DbContextOptions<OrdersDbContext> _options;

    public OrderRepositoryTests()
    {
        _connection.Open();
        _options = new DbContextOptionsBuilder<OrdersDbContext>().UseSqlite(_connection).Options;

        using var dbContext = new OrdersDbContext(_options);
        dbContext.Database.EnsureCreated();
    }

    [Fact]
    public async Task SavedOrder_LoadsBackWithItsItems()
    {
        var orderId = await SaveNewOrderAsync();

        var loaded = await LoadAsync(orderId);

        Assert.NotNull(loaded);
        Assert.Equal(2, loaded.Items.Count);
        Assert.Equal(106.25m, loaded.Total);
    }

    [Fact]
    public async Task ChangesToALoadedOrder_ReachTheDatabase()
    {
        var orderId = await SaveNewOrderAsync();

        await using (var dbContext = new OrdersDbContext(_options))
        {
            var repository = new OrderRepository(dbContext);
            var order = await repository.GetByIdAsync(orderId, TestContext.Current.CancellationToken);

            order!.RemoveItem(DutchOven);
            order.AddQuantity(Skillet, 1);
            order.AddPayment(59.80m);

            await repository.SaveChangesAsync(TestContext.Current.CancellationToken);
        }

        var reloaded = await LoadAsync(orderId);

        var skillet = Assert.Single(reloaded!.Items);
        Assert.Equal(2, skillet.Quantity);
        Assert.Equal(59.80m, reloaded.PaidAmount);
        Assert.Equal(OrderStatus.ReadyForShipping, reloaded.Status);
    }

    [Fact]
    public async Task GetByIdAsync_ForAnUnknownId_ReturnsNull()
    {
        var loaded = await LoadAsync(42);

        Assert.Null(loaded);
    }

    private async Task<long> SaveNewOrderAsync()
    {
        var order = Order.Create(TimeProvider.System);
        order.AddItem(DutchOven, 1, 76.35m);
        order.AddItem(Skillet, 1, 29.90m);

        await using var dbContext = new OrdersDbContext(_options);
        var repository = new OrderRepository(dbContext);
        repository.Add(order);
        await repository.SaveChangesAsync(TestContext.Current.CancellationToken);

        return order.Id;
    }

    private async Task<Order?> LoadAsync(long orderId)
    {
        await using var dbContext = new OrdersDbContext(_options);

        return await new OrderRepository(dbContext).GetByIdAsync(orderId, TestContext.Current.CancellationToken);
    }

    public void Dispose() => _connection.Dispose();
}
