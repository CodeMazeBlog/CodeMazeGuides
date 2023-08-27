namespace OnChangeEventWithSelectDropdownTests;

[TestClass]
public class BurgerConfiguratorTests
{
    [TestMethod]
    public async Task TestBurgerConfigurator()
    {
        // Arrange
        using var testContext = new Bunit.TestContext();
        var component = testContext.RenderComponent<OnChangeEventWithSelectDropdown.Pages.Index>();

        // Act
        var baseBurgerCostElement = component.Find("p:nth-of-type(1)");
        var selectedToppingElement = component.Find("p:nth-of-type(2)");
        var totalCostElement = component.Find("p:nth-of-type(3)");
        var grandTotalElement = component.Find("p:nth-of-type(4)");

        // Assert initial state
        Assert.AreEqual("Burger without topping: 5.4", baseBurgerCostElement.TextContent.Trim());
        Assert.AreEqual("Topping:", selectedToppingElement.TextContent.Trim());
        Assert.AreEqual("Total Cost: 5.4", totalCostElement.TextContent.Trim());
        Assert.AreEqual("Grand Total: 0", grandTotalElement.TextContent.Trim());

        // Simulate selecting a topping
        var toppingSelectElement = component.Find(".select-element");
        toppingSelectElement.Change(2); // Select "Cheese" (Id: 2)

        // Assert updated state after selecting a topping
        Assert.AreEqual("Burger without topping: 5.4", baseBurgerCostElement.TextContent.Trim());
        Assert.AreEqual("Topping: Cheese", selectedToppingElement.TextContent.Trim());
        Assert.AreEqual("Total Cost: 7.8", totalCostElement.TextContent.Trim());

        // Simulate selecting a second topping
        var secondToppingSelectElement = component.Find("select:nth-of-type(2)");
        secondToppingSelectElement.Change(3); // Select "Onions" (Id: 3)
        await component.InvokeAsync(() => component.Instance.selectedSecondTopping = "3");
        await component.InvokeAsync(() => component.Instance.calculateGrandTotal());

        // Assert updated state after selecting second topping
        Assert.AreEqual("Grand Total: 8.5", grandTotalElement.TextContent.Trim());
    }
}
