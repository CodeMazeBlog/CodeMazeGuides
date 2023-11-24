using RefactoringCouplers.FeatureEnvy.Correct;

namespace Tests.FeatureEnvy;

[TestClass]
public class TicketTests
{
    [TestMethod]
    public void WhenTicketIsAvailableAndCustomerCanAfford_ThenShouldReturnPriceAndTicketShouldNotBeAvailable()
    {
        // Arrange
        var ticketPrice = 200;
        var ticket = new Ticket(true, ticketPrice);
        var points = 300;

        // Act
        var result = ticket.TryToBuyTicket(points);

        // Assert
        Assert.IsTrue(result == ticketPrice);
        Assert.IsFalse(ticket.IsAvailable);
    }

    [TestMethod]
    public void WhenTicketIsNotAvailable_ThenShouldReturnZero()
    {
        // Arrange
        var ticket = new Ticket(false, 200);
        var points = 300;

        // Act
        var result = ticket.TryToBuyTicket(points);

        // Assert
        Assert.IsTrue(result == 0);
    }

    [TestMethod]
    public void WhenCustomerCannotAfford_ThenShouldReturnZeroAndTicketShouldRemainAvailable()
    {
        // Arrange
        var ticket = new Ticket(true, 200);
        var points = 100;

        // Act
        var result = ticket.TryToBuyTicket(points);

        // Assert
        Assert.IsTrue(result == 0);
        Assert.IsTrue(ticket.IsAvailable);
    }
}