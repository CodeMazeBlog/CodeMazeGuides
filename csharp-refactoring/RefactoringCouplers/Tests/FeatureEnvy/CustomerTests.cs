using RefactoringCouplers.FeatureEnvy.Correct;

namespace Tests.FeatureEnvy;

[TestClass]
public class CustomerTests
{
    [TestMethod]
    public void WhenExchangingPointsToTicket_ThenShouldBuyTicketAndSubtractPoints()
    {
        // Arrange
        const int ticketPrice = 200;
        const int customerPointsBefore = 300;
        var ticket = new Ticket(true, ticketPrice);
        var customer = new Customer("John")
        {
            Points = customerPointsBefore
        };

        // Act
        customer.ExchangePointsToTicket(ticket);

        // Assert
        Assert.AreEqual(customerPointsBefore - ticketPrice, customer.Points);
        Assert.IsFalse(ticket.IsAvailable);
    }

    [TestMethod]
    public void WhenExchangingPointsToTicketAndCustomerCannotAfford_ThenShouldNotBuyTicketAndNotSubtractPoints()
    {
        // Arrange
        const int customerPointsBefore = 100;
        var ticket = new Ticket(true, 200);
        var customer = new Customer("Jane")
        {
            Points = customerPointsBefore
        };

        // Act
        customer.ExchangePointsToTicket(ticket);

        // Assert
        Assert.AreEqual(customerPointsBefore, customer.Points);
        Assert.IsTrue(ticket.IsAvailable);
    }
}
