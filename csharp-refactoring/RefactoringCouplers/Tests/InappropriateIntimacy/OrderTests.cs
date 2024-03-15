using RefactoringCouplers.InappropriateIntimacy.Correct;

namespace Tests.InappropriateIntimacy;

[TestClass]
public class OrderTests
{
    [TestMethod]
    public void WhenProcessingOrder_ThenOrderForActiveCustomerShouldBeFinalized()
    {
        // Arrange
        var order = new Order();
        var customer = new Customer { IsActive = true };
        order.OrderNumber = "123";

        // Act
        order.ProcessOrder(customer);

        // Assert
        Assert.IsTrue(order.IsFinalized);
        CollectionAssert.Contains(customer.FinalizedOperations.ToList(), order.OrderNumber);
    }

    [TestMethod]
    public void WhenProcessingOrder_ThenOrderForInactiveCustomerShouldNotBeFinalized()
    {
        // Arrange
        var order = new Order();
        var customer = new Customer { IsActive = false };
        order.OrderNumber = "456";

        // Act
        order.ProcessOrder(customer);

        // Assert
        Assert.IsFalse(order.IsFinalized);
        CollectionAssert.DoesNotContain(customer.FinalizedOperations.ToList(), order.OrderNumber);
    }
}