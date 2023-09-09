using System.ComponentModel;

namespace OnChangeEventWithSelectDropdownTests;

[TestClass]
public class BurgerConfiguratorTests
{
    [TestMethod]
    public void TestToppingWithBurgerConfigurator()
    {
        using var testContext = new Bunit.TestContext();
        var component = testContext.RenderComponent<OnChangeEventWithSelectDropdown.Pages.Index>();

        var baseBurgerCostElement = component.Find("p:nth-of-type(1)");
        var selectedToppingElement = component.Find("p:nth-of-type(2)");
        var totalCostElement = component.Find("p:nth-of-type(3)");
        var grandTotalElement = component.Find("p:nth-of-type(4)");

        Assert.AreEqual("Burger without topping: $5.4", baseBurgerCostElement.TextContent.Trim());
        Assert.AreEqual("Free topping:", selectedToppingElement.TextContent.Trim());
        Assert.AreEqual("Total Cost: $5.4", totalCostElement.TextContent.Trim());

        var toppingSelectElement = component.Find("select:nth-of-type(1)");
        toppingSelectElement.Change(2); // Select "Cheese" (Id: 2)

        Assert.AreEqual("Burger without topping: $5.4", baseBurgerCostElement.TextContent.Trim());
        Assert.AreEqual("Free topping: 2", selectedToppingElement.TextContent.Trim());
        Assert.AreEqual("Total Cost: $5.4", totalCostElement.TextContent.Trim());

        var toppingSecondSelectElement = component.Find("select:nth-of-type(2)");
        toppingSecondSelectElement.Change(2); // Select "Cheese (Id: 2)

        Assert.AreEqual("Burger without topping: $5.4", baseBurgerCostElement.TextContent.Trim());
        Assert.AreEqual("Total Cost: $7.8", totalCostElement.TextContent.Trim());
    }

    [TestMethod]
    public async Task TestThirdToppingWithBurgerConfigurator()
    {
        using var testContext = new Bunit.TestContext();
        var component = testContext.RenderComponent<OnChangeEventWithSelectDropdown.Pages.Index>();

        var totalCostElement = component.Find("p:nth-of-type(3)");
        var grandTotalElement = component.Find("p:nth-of-type(4)");

        Assert.AreEqual("Total Cost: $5.4", totalCostElement.TextContent.Trim());
        Assert.AreEqual("Grand Total: $0", grandTotalElement.TextContent.Trim());

        var thirdToppingSelectElement = component.Find("select:nth-of-type(3)");
        thirdToppingSelectElement.Change(3); // Select "Onions" (Id: 3)
        await component.InvokeAsync(() => component.Instance.selectedSecondTopping = "3");
        await component.InvokeAsync(() => component.Instance.CalculateGrandTotal());

        await Task.Delay(TimeSpan.FromSeconds(3));

        Assert.AreEqual("Grand Total: $6.1", grandTotalElement.TextContent.Trim());
    }
}
