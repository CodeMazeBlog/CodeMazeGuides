using System.Threading.Tasks;
using Xunit;
using MultiTenantApplication.Core.Abstractions;
using MultiTenantApplication.Core;
using Microsoft.EntityFrameworkCore;
using MultiTenantApplication.Infrastructure.Data;
using MultiTenantApplication.Infrastructure.Repositories;
using Moq;

namespace MultiTenantApplication.Tests;

public class MultiTenantApiTest
{
    private readonly Tenant _tenantA = new() { Name = "BranchA" };
    private readonly Tenant _tenantB = new() { Name = "BranchB" };
    private readonly Tenant _tenantC = new() { Name = "BranchC" };

    private readonly DbContextOptions _contextOptions;

    public MultiTenantApiTest()
    {
        _contextOptions = new DbContextOptionsBuilder<InventoryDbContext>()
            .UseInMemoryDatabase("InventoryTestDb")
            .Options;

        // Ensure clean db
        using var db = CreateDbContext(_tenantA);
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
    }

    [Fact]
    public async Task GivenGoodsRepository_WhenAddingGoods_ThenRightlyAssociateTenant()
    {
        // Given
        var repository = GetRepository(_tenantA);

        // When
        var goodsA = await repository.AddAsync(new GoodsDto("A001", 11));

        // Then
        Assert.NotNull(goodsA);
        Assert.Equal(goodsA!.TenantId, _tenantA.Name);
    }

    [Fact]
    public async Task GivenGoodsRepository_WhenRequestedForGoodsList_ThenReturnGoodsForCallerTenant()
    {
        // Given
        var goodsA = await GetRepository(_tenantA).AddAsync(new GoodsDto("A001", 11));

        var goodsB = await GetRepository(_tenantB).AddAsync(new GoodsDto("B001", 21));

        var goodsC = await GetRepository(_tenantC).AddAsync(new GoodsDto("C001", 31));

        // When
        var listB = await GetRepository(_tenantB).GetAllAsync();

        // Then
        Assert.NotEmpty(listB);
        Assert.All(listB, e => Assert.Equal(e.TenantId, _tenantB.Name));
        Assert.Contains(listB, e => e.Name == goodsB.Name);
        Assert.DoesNotContain(listB, e => e.Name == goodsA.Name);
        Assert.DoesNotContain(listB, e => e.Name == goodsC.Name);
    }

    IGoodsRepository GetRepository(Tenant tenant)
    {
        return new GoodsRepository(CreateDbContext(tenant));
    }

    InventoryDbContext CreateDbContext(Tenant tenant)
    {
        var mock = new Mock<ITenantResolver>();
        mock.Setup(m => m.GetCurrentTenant()).Returns(tenant);

        return new InventoryDbContext(_contextOptions, mock.Object);
    }
}