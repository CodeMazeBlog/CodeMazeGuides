namespace OnChangeEventWithSelectDropdownTests;

[TestClass]
public class BurgerConfiguratorTests
{
    [TestMethod]
    public void TestBurgerConfigurator()
    {
        // Arrange
        using var ctx = new Bunit.TestContext();
        var component = ctx.RenderComponent<OnChangeEventWithSelectDropdown.Pages.Index>();

        // Act
        var baseBurgerCostElement = component.Find("p:nth-of-type(1)");
        var selectedToppingElement = component.Find("p:nth-of-type(2)");
        var totalCostElement = component.Find("p:nth-of-type(3)");

        // Assert initial state
        Assert.AreEqual("Burger without topping: 5.4", baseBurgerCostElement.TextContent.Trim());
        Assert.AreEqual("Topping:", selectedToppingElement.TextContent.Trim());
        Assert.AreEqual("Total Cost: 5.4", totalCostElement.TextContent.Trim());

        // Simulate selecting a topping
        var toppingSelectElement = component.Find(".select-element");
        toppingSelectElement.Change(2); // Select "Cheese" (Id: 2)

        // Assert updated state after selecting a topping
        Assert.AreEqual("Burger without topping: 5.4", baseBurgerCostElement.TextContent.Trim());
        Assert.AreEqual("Topping: Cheese", selectedToppingElement.TextContent.Trim());
        Assert.AreEqual("Total Cost: 7.8", totalCostElement.TextContent.Trim());
    }
}

