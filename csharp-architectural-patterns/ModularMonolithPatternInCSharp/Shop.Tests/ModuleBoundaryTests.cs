using NetArchTest.Rules;
using Shop.Inventory;
using Shop.Orders;

namespace Shop.Tests;

public class ModuleBoundaryTests
{
    [Fact]
    public void Orders_DoesNotDependOnInventory()
    {
        var result = Types.InAssembly(typeof(OrdersModule).Assembly)
            .ShouldNot()
            .HaveDependencyOn("Shop.Inventory")
            .GetResult();

        Assert.True(result.IsSuccessful, "Offending types: " + string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void Inventory_DoesNotDependOnOrders()
    {
        var result = Types.InAssembly(typeof(InventoryModule).Assembly)
            .ShouldNot()
            .HaveDependencyOn("Shop.Orders")
            .GetResult();

        Assert.True(result.IsSuccessful, "Offending types: " + string.Join(", ", result.FailingTypeNames ?? []));
    }

    [Fact]
    public void InventoryDomainAndApplication_DoNotDependOnInfrastructure()
    {
        var result = Types.InAssembly(typeof(InventoryModule).Assembly)
            .That().ResideInNamespace("Shop.Inventory.Domain")
            .Or().ResideInNamespace("Shop.Inventory.Application")
            .ShouldNot()
            .HaveDependencyOn("Shop.Inventory.Infrastructure")
            .GetResult();

        Assert.True(result.IsSuccessful, "Offending types: " + string.Join(", ", result.FailingTypeNames ?? []));
    }
}
