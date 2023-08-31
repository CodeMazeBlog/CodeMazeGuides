using ExpandingLIQNwithMoreLINQ;

namespace MoreLINQ.Tests
{
    public class TicketTests
    {
        [Fact]
        public void GivenNoParameters_WhenConstructorIsInvoked_ThenValidTicketIsReturned()
        {
            // Act
            var ticket = new Ticket();

            // Assert
            ticket.Should().NotBeNull();
        }

        [Fact]
        public void GivenValidParameters_WhenConstructorIsInvoked_ThenValidTicketIsReturned()
        {
            // Arrange
            var ticketNumber = 1;
            var seatNumber = 1;
            var passengerName = "John Doe";
            string ticketClass = "First class";
            decimal price = 99.99m;

            // Act
            var ticket = new Ticket(ticketNumber, seatNumber, passengerName, ticketClass, price);

            // Assert
            ticket.Should().NotBeNull();
            ticket.TicketNumber.Should().Be(ticketNumber);
            ticket.SeatNumber.Should().Be(seatNumber);
            ticket.PassengerName.Should().Be(passengerName);
            ticket.Price.Should().Be(price);
        }
    }
}