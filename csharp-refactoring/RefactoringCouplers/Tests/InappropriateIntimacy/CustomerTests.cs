using RefactoringCouplers.InappropriateIntimacy.Correct;

namespace Tests.InappropriateIntimacy;

[TestClass]
public class CustomerTests
{
    [TestMethod]
    public void WhenFinalizingOrder_ThenOrderNumberShouldBeAddedToFinalizedOperations()
    {
        // Arrange
        var customer = new Customer { IsActive = true };
        var orderNumber = "789";

        // Act
        customer.FinalizeOrder(orderNumber);

        // Assert
        CollectionAssert.Contains(customer.FinalizedOperations.ToList(), orderNumber);
    }

    [TestMethod]
    public void WhenFinalizingOrder_ThenOrderNumberShouldNotBeAddedToFinalizedOperations()
    {
        // Arrange
        var customer = new Customer { IsActive = false };
        var orderNumber = "1011";

        // Act
        customer.FinalizeOrder(orderNumber);

        // Assert
        CollectionAssert.DoesNotContain(customer.FinalizedOperations.ToList(), orderNumber);
    }
}