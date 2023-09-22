[TestClass]
public class FuncUnitTest
{
    [TestMethod]
    public void WhenProcessingShippingWithStandardCostCalculator_ThenReturnCorrectCost()
    {
        // Arrange
        ShippingProcessor processor = new ShippingProcessor();
        decimal weight = 10; // in kilograms
        decimal distance = 100; // in kilometers
        decimal expectedCost = weight * distance * 0.02m; // Expected cost using standard cost calculator
        // Act
        decimal actualCost = 0;
        processor.ProcessShipping(weight, distance, (total) => actualCost = total * 0.02m);
        // Assert
        Assert.AreEqual(expectedCost, actualCost, "Shipping cost is not calculated correctly using standard cost calculator.");
    }
    [TestMethod]
    public void WhenProcessingShippingWithExpressCostCalculator_ThenReturnCorrectCost()
    {
        // Arrange
        ShippingProcessor processor = new ShippingProcessor();
        decimal weight = 10; // in kilograms
        decimal distance = 100; // in kilometer
        decimal expectedCost = weight * distance * 0.05m; // Expected cost using express cost calculator
        // Act
        decimal actualCost = 0;
        processor.ProcessShipping(weight, distance, (total) => actualCost = total * 0.05m);
        // Assert
        Assert.AreEqual(expectedCost, actualCost, "Shipping cost is not calculated correctly using express cost calculator.");
    }
}

