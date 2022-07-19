using System.Threading.Tasks;
using Xunit;
using MultiTenantApplication.Core.Abstractions;
using MultiTenantApplication.Core;
using Microsoft.EntityFrameworkCore;
using MultiTenantApplication.Infrastructure.Data;
using MultiTenantApplication.Infrastructure.Repositories;

#nullable disable

namespace MultiTenantApplication.Tests;

public class MultiTenantApiTest
{
    private readonly Tenant _tenantA = new() { Name = "BranchA", Secret = "secretA" };
    private readonly Tenant _tenantB = new() { Name = "BranchB", Secret = "secretB" };
    private readonly Tenant _tenantC = new() { Name = "BranchC", Secret = "secretC" };

    private readonly DbContextOptions _contextOptions;

    public MultiTenantApiTest()
    {
        _contextOptions = new DbContextOptionsBuilder<InventoryDbContext>()
            .UseInMemoryDatabase("InventoryTestDb")
            .Options;

        // Ensure clean db
        using var db = new InventoryDbContext(_contextOptions, new TestTenantResolver(_tenantA));
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
    }

    [Fact]
    public async Task GivenGoodsRepository_WhenAddingGoods_ThenRightlyAssociateTenant()
    {
        var repository = GetRepository(_tenantA);

        var goodsA = await repository.AddAsync(new GoodsDto("A001", 11));

        Assert.NotNull(goodsA);
        Assert.Equal(goodsA!.TenantId, _tenantA.Name);
    }

    [Fact]
    public async Task GivenGoodsRepository_WhenRequestedForGoodsList_ThenReturnGoodsForCallerTenant()
    {
        // Seed
        var goodsA = await GetRepository(_tenantA).AddAsync(new GoodsDto("A001", 11));

        var goodsB = await GetRepository(_tenantB).AddAsync(new GoodsDto("B001", 21));

        var goodsC = await GetRepository(_tenantC).AddAsync(new GoodsDto("C001", 31));

        // Fetch list of tenant A
        var listA = await GetRepository(_tenantA).GetAllAsync();

        Assert.NotEmpty(listA);
        Assert.All(listA, e => Assert.Equal(e.TenantId, _tenantA.Name));
        Assert.Contains(listA, e => e.Name == goodsA.Name);
        Assert.DoesNotContain(listA, e => e.Name == goodsB.Name);
        Assert.DoesNotContain(listA, e => e.Name == goodsC.Name);

        // Fetch list of tenant B
        var listB = await GetRepository(_tenantB).GetAllAsync();

        Assert.NotEmpty(listB);
        Assert.All(listB, e => Assert.Equal(e.TenantId, _tenantB.Name));
        Assert.Contains(listB, e => e.Name == goodsB.Name);
        Assert.DoesNotContain(listB, e => e.Name == goodsA.Name);
        Assert.DoesNotContain(listB, e => e.Name == goodsC.Name);

        // Fetch list of tenant C
        var listC = await GetRepository(_tenantC).GetAllAsync();

        Assert.NotEmpty(listC);
        Assert.All(listC, e => Assert.Equal(e.TenantId, _tenantC.Name));
        Assert.Contains(listC, e => e.Name == goodsC.Name);
        Assert.DoesNotContain(listC, e => e.Name == goodsA.Name);
        Assert.DoesNotContain(listC, e => e.Name == goodsB.Name);
    }

    IGoodsRepository GetRepository(Tenant tenant)
    {
        var db = new InventoryDbContext(_contextOptions, new TestTenantResolver(tenant));

        return new GoodsRepository(db);
    }

    class TestTenantResolver : ITenantResolver
    {
        private readonly Tenant _tenant;

        public TestTenantResolver(Tenant tenant) => _tenant = tenant;

        public Tenant GetCurrentTenant() => _tenant;
    }
}
