using Bogus;
using ExpandingLIQNwithMoreLINQ;

namespace ExpandingLINQwithMoreLINQ.Tests
{
    public class FlightTests
    {
        [Fact]
        public void GivenValidParameters_WhenConstructorIsInvoked_ThenValidFlightIsReturned()
        {
            // Arrange
            int flightNumber = 1;
            string departureCity = "Sofia, Bulgaria";
            string arrivalCity = "Nis, Serbia";
            DateTime departureTime = DateTime.UtcNow;
            DateTime arrivalTime = DateTime.UtcNow;

            // Act
            var flight = new Flight(flightNumber, departureCity, arrivalCity, departureTime, arrivalTime);

            // Assert
            flight.Should().NotBeNull();
            flight.FlightNumber.Should().Be(flightNumber);
            flight.DepartureCity.Should().Be(departureCity);
            flight.ArrivalCity.Should().Be(arrivalCity);
            flight.DepartureCity.Should().Be(departureCity);
            flight.ArrivalTime.Should().Be(arrivalTime);
        }

        [Fact]
        public void GivenFreeSeats_WhenAddTicketIsInvoked_ThenTicketIsAdded()
        {
            // Arrange
            int flightNumber = 1;
            int ticketsCount = 30;
            string departureCity = "Sofia, Bulgaria";
            string arrivalCity = "Nis, Serbia";
            DateTime departureTime = DateTime.UtcNow;
            DateTime arrivalTime = DateTime.UtcNow;

            var flight = new Flight(
                flightNumber,
                departureCity,
                arrivalCity,
                departureTime,
                arrivalTime);

            for (int i = 0; i < ticketsCount; i++)
            {
                flight.AddTicket(GetBogusticket());
            }

            // Act
            flight.AddTicket(GetBogusticket());

            // Assert
            flight.Tickets.Should().HaveCount(ticketsCount + 1);
        }

        [Fact]
        public void GivenNoFreeSeats_WhenAddTicketIsInvoked_ThenTicketIsNotAdded()
        {
            // Arrange
            int flightNumber = 1;
            int ticketsCount = 50;
            string departureCity = "Sofia, Bulgaria";
            string arrivalCity = "Nis, Serbia";
            DateTime departureTime = DateTime.UtcNow;
            DateTime arrivalTime = DateTime.UtcNow;

            var flight = new Flight(
                flightNumber,
                departureCity,
                arrivalCity,
                departureTime,
                arrivalTime);

            for (int i = 0; i < ticketsCount; i++)
            {
                flight.AddTicket(GetBogusticket());
            }

            // Act
            flight.AddTicket(GetBogusticket());

            // Assert
            flight.Tickets.Should().HaveCount(ticketsCount);
        }

        [Fact]
        public void WhenGetCheapestTicketsIsInvoked_ThenCheapestTicketsAreReturned()
        {
            // Arrange
            int flightNumber = 1;
            int ticketsCount = 20;
            string departureCity = "Sofia, Bulgaria";
            string arrivalCity = "Nis, Serbia";
            DateTime departureTime = DateTime.UtcNow;
            DateTime arrivalTime = DateTime.UtcNow;

            var flight = new Flight(
                flightNumber,
                departureCity,
                arrivalCity,
                departureTime,
                arrivalTime);

            for (int i = 0; i < ticketsCount; i++)
            {
                flight.AddTicket(GetBogusticket());
            }

            // Act
            var cheapestTickets = flight.GetCheapestTickets();

            // Assert
            cheapestTickets.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void WhenGetMostExpensiveTicketsIsInvoked_ThenMostExpensiveTicketsAreReturned()
        {
            // Arrange
            int flightNumber = 1;
            int ticketsCount = 20;
            string departureCity = "Sofia, Bulgaria";
            string arrivalCity = "Nis, Serbia";
            DateTime departureTime = DateTime.UtcNow;
            DateTime arrivalTime = DateTime.UtcNow;

            var flight = new Flight(
                flightNumber,
                departureCity,
                arrivalCity,
                departureTime,
                arrivalTime);

            for (int i = 0; i < ticketsCount; i++)
            {
                flight.AddTicket(GetBogusticket());
            }

            // Act
            var mostExpensiveTickets = flight.GetMostExpensiveTickets();

            // Assert
            mostExpensiveTickets.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GivenFreeSeats_WhenAreThereFreeSeatsIsInvoked_ThenTrueIsReturned()
        {
            // Arrange
            int flightNumber = 1;
            int ticketsCount = 20;
            string departureCity = "Sofia, Bulgaria";
            string arrivalCity = "Nis, Serbia";
            DateTime departureTime = DateTime.UtcNow;
            DateTime arrivalTime = DateTime.UtcNow;

            var flight = new Flight(
                flightNumber,
                departureCity,
                arrivalCity,
                departureTime,
                arrivalTime);

            for (int i = 0; i < ticketsCount; i++)
            {
                flight.AddTicket(GetBogusticket());
            }

            // Act
            var areThereFreeSeats = flight.AreThereFreeSeats();

            //
            areThereFreeSeats.Should().BeTrue();
        }

        [Fact]
        public void GivenNoFreeSeats_WhenAreThereFreeSeatsIsInvoked_ThenFalseIsReturned()
        {
            // Arrange
            int flightNumber = 1;
            int ticketsCount = 50;
            string departureCity = "Sofia, Bulgaria";
            string arrivalCity = "Nis, Serbia";
            DateTime departureTime = DateTime.UtcNow;
            DateTime arrivalTime = DateTime.UtcNow;

            var flight = new Flight(
                flightNumber,
                departureCity,
                arrivalCity,
                departureTime,
                arrivalTime);

            for (int i = 0; i < ticketsCount; i++)
            {
                flight.AddTicket(GetBogusticket());
            }

            // Act
            var areThereFreeSeats = flight.AreThereFreeSeats();

            //
            areThereFreeSeats.Should().BeFalse();
        }

        [Fact]
        public void GivenEnoughPassengers_WhenWillFligthTakePlaceIsInvoked_ThenTrueIsReturned()
        {
            // Arrange
            int flightNumber = 1;
            int ticketsCount = 21;
            string departureCity = "Sofia, Bulgaria";
            string arrivalCity = "Nis, Serbia";
            DateTime departureTime = DateTime.UtcNow;
            DateTime arrivalTime = DateTime.UtcNow;

            var flight = new Flight(
                flightNumber,
                departureCity,
                arrivalCity,
                departureTime,
                arrivalTime);

            for (int i = 0; i < ticketsCount; i++)
            {
                flight.AddTicket(GetBogusticket());
            }

            // Act
            var willFlightTakePlace = flight.WillFligthTakePlace();

            //
            willFlightTakePlace.Should().BeTrue();
        }

        [Fact]
        public void GivenNotEnoughPassengers_WhenWillFligthTakePlaceIsInvoked_ThenFalseIsReturned()
        {
            // Arrange
            int flightNumber = 1;
            int ticketsCount = 19;
            string departureCity = "Sofia, Bulgaria";
            string arrivalCity = "Nis, Serbia";
            DateTime departureTime = DateTime.UtcNow;
            DateTime arrivalTime = DateTime.UtcNow;

            var flight = new Flight(
                flightNumber,
                departureCity,
                arrivalCity,
                departureTime,
                arrivalTime);

            for (int i = 0; i < ticketsCount; i++)
            {
                flight.AddTicket(GetBogusticket());
            }

            // Act
            var willFlightTakePlace = flight.WillFligthTakePlace();

            //
            willFlightTakePlace.Should().BeFalse();
        }

        [Fact]
        public void WhenGetBordingGroupsIsInvoked_ThenAccurateNumberOfGroupsIsReturned()
        {
            // Arrange
            int flightNumber = 1;
            int ticketsCount = 30;
            string departureCity = "Sofia, Bulgaria";
            string arrivalCity = "Nis, Serbia";
            DateTime departureTime = DateTime.UtcNow;
            DateTime arrivalTime = DateTime.UtcNow;

            var flight = new Flight(
                flightNumber,
                departureCity,
                arrivalCity,
                departureTime,
                arrivalTime);

            for (int i = 0; i < ticketsCount; i++)
            {
                flight.AddTicket(GetBogusticket());
            }

            // Act
            var boardingGroups = flight.GetBordingGroups(4);

            //
            boardingGroups.Should().NotBeNullOrEmpty();
            boardingGroups.Count().Should().Be(4);
        }

        [Fact]
        public void WhenGetPassengersForSecurityCheckIsInvoked_ThenAccurateNumberOfPassangersIsReturned()
        {
            // Arrange
            int flightNumber = 1;
            int ticketsCount = 30;
            string departureCity = "Sofia, Bulgaria";
            string arrivalCity = "Nis, Serbia";
            DateTime departureTime = DateTime.UtcNow;
            DateTime arrivalTime = DateTime.UtcNow;

            var flight = new Flight(
                flightNumber,
                departureCity,
                arrivalCity,
                departureTime,
                arrivalTime);

            for (int i = 0; i < ticketsCount; i++)
            {
                flight.AddTicket(GetBogusticket());
            }

            // Act
            var passengersForSecurityCheck = flight.GetPassengersForSecurityCheck();

            //
            passengersForSecurityCheck.Should().NotBeNullOrEmpty();
            passengersForSecurityCheck.Count().Should().Be(6);
        }

        private static Faker<Ticket> GetTicketGenerator()
        {
            return new Faker<Ticket>()
                .RuleFor(x => x.TicketNumber, f => f.Random.Int(1, 100))
                .RuleFor(x => x.SeatNumber, f => f.Random.Int(1, 100))
                .RuleFor(x => x.PassengerName, f => f.Name.FullName())
                .RuleFor(x => x.TicketClass, f => f.PickRandom("First class", "Bussines class", "Economy class"))
                .RuleFor(x => x.Price, f => f.Random.Decimal(20.00m, 250.00m));
        }

        private static Ticket GetBogusticket() => GetTicketGenerator().Generate();
    }
}
