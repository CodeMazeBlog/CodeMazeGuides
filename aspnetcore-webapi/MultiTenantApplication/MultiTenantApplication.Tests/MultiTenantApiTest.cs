using MultiTenantApplication.Api.Controllers;
using System.Threading.Tasks;
using Xunit;

#nullable disable

namespace MultiTenantApplication.Tests;

public class MultiTenantApiTest
{
    private readonly User _tenantA = new("BranchA", "secretA");
    private readonly User _tenantB = new("BranchB", "secretB");
    private readonly User _tenantC = new("BranchC", "secretC");

    [Fact]
    public async Task GivenInventoryApi_WhenReceiveAddGoodsRequest_ThenStoreGoodsForCallerTenant()
    {
        var api = new InventoryApiClient();

        await api.LoginAsync(_tenantA);

        var goodsA = await api.AddAsync(new Core.GoodsDto("A001", 11));

        Assert.NotNull(goodsA);
        Assert.Equal(goodsA!.TenantId, _tenantA.UserName);

        await api.LoginAsync(_tenantB);

        var goodsB = await api.AddAsync(new Core.GoodsDto("B001", 21));

        Assert.NotNull(goodsB);
        Assert.Equal(goodsB!.TenantId, _tenantB.UserName);
    }

    [Fact]
    public async Task GivenInventoryApi_WhenReceiveGetGoodsListRequest_ThenReturnGoodsForCallerTenant()
    {
        var api = new InventoryApiClient();

        await api.LoginAsync(_tenantA);

        var goodsA = await api.AddAsync(new Core.GoodsDto("A001", 11));

        await api.LoginAsync(_tenantB);

        var goodsB = await api.AddAsync(new Core.GoodsDto("B001", 21));

        await api.LoginAsync(_tenantC);

        var goodsC = await api.AddAsync(new Core.GoodsDto("C001", 31));

        var listC = await api.GetListAsync();

        Assert.NotEmpty(listC);
        Assert.All(listC, e => Assert.Equal(e.TenantId, _tenantC.UserName));
        Assert.Contains(listC, e => e.Name == goodsC.Name);
        Assert.DoesNotContain(listC, e => e.Name == goodsA.Name);
        Assert.DoesNotContain(listC, e => e.Name == goodsB.Name);

        // Tenant B login and fetch list
        await api.LoginAsync(_tenantB);

        var listB = await api.GetListAsync();

        Assert.NotEmpty(listB);
        Assert.All(listB, e => Assert.Equal(e.TenantId, _tenantB.UserName));
        Assert.Contains(listB, e => e.Name == goodsB.Name);
        Assert.DoesNotContain(listB, e => e.Name == goodsA.Name);
        Assert.DoesNotContain(listB, e => e.Name == goodsC.Name);

        // Tenant A login and fetch list
        await api.LoginAsync(_tenantA);

        var listA = await api.GetListAsync();

        Assert.NotEmpty(listA);
        Assert.All(listA, e => Assert.Equal(e.TenantId, _tenantA.UserName));
        Assert.Contains(listA, e => e.Name == goodsA.Name);
        Assert.DoesNotContain(listA, e => e.Name == goodsB.Name);
        Assert.DoesNotContain(listA, e => e.Name == goodsC.Name);
    }
}
