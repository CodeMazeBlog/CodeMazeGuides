namespace OverwriteDateTimeDuringTesting.Tests;

public class FlightNotificationServiceTests
{
    private readonly FakeTimeProvider _timeProvider;

    public FlightNotificationServiceTests()
    {
        _timeProvider = new FakeTimeProvider();
    }

    [Fact]
    public void GivenMoreThanTwoHours_WhenGetFlightNotificationMessageIsInvoked_ThenCorrectMessageIsReturned()
    {
        // Arrange
        var flight = new Flight
        {
            From = "Heathrow Airport",
            To = "John F. Kennedy International Airport",
            Time = new DateTime(2024, 02, 05, 15, 00, 00)
        };
        _timeProvider.SetUtcNow(new DateTime(2024, 02, 05, 10, 00, 00));
        var expectedMessage = string.Format(Messages.FlightDepartsInMoreThanTwoHours, flight.From, flight.To);
        var sut = new FlightNotificationService(_timeProvider);

        // Act
        var result = sut.GetFlightNotificationMessage(flight);

        // Assert
        result.Should().Be(expectedMessage);
    }

    [Fact]
    public void GivenLessThanTwoHours_WhenGetFlightNotificationMessageIsInvoked_ThenCorrectMessageIsReturned()
    {
        // Arrange
        var flight = new Flight
        {
            From = "Heathrow Airport",
            To = "John F. Kennedy International Airport",
            Time = new DateTime(2024, 02, 05, 15, 00, 00)
        };
        _timeProvider.SetUtcNow(new DateTime(2024, 02, 05, 13, 01, 00));
        var expectedMessage = string.Format(Messages.FlightDepartsInLessThanTwoHours, flight.From, flight.To);
        var sut = new FlightNotificationService(_timeProvider);

        // Act
        var result = sut.GetFlightNotificationMessage(flight);

        // Assert
        result.Should().Be(expectedMessage);
    }

    [Fact]
    public void GivenLessThanOneHours_WhenGetFlightNotificationMessageIsInvoked_ThenCorrectMessageIsReturned()
    {
        // Arrange
        var flight = new Flight
        {
            From = "Heathrow Airport",
            To = "John F. Kennedy International Airport",
            Time = new DateTime(2024, 02, 05, 15, 00, 00)
        };
        _timeProvider.SetUtcNow(new DateTime(2024, 02, 05, 14, 01, 00));
        var expectedMessage = string.Format(Messages.FlightDepartsInLessThanOneHour, flight.From, flight.To);
        var sut = new FlightNotificationService(_timeProvider);

        // Act
        var result = sut.GetFlightNotificationMessage(flight);

        // Assert
        result.Should().Be(expectedMessage);
    }

    [Fact]
    public void GivenLessThanThirtyMinutes_WhenGetFlightNotificationMessageIsInvoked_ThenCorrectMessageIsReturned()
    {
        // Arrange
        var flight = new Flight
        {
            From = "Heathrow Airport",
            To = "John F. Kennedy International Airport",
            Time = new DateTime(2024, 02, 05, 15, 00, 00)
        };
        _timeProvider.SetUtcNow(new DateTime(2024, 02, 05, 14, 31, 00));
        var expectedMessage = string.Format(Messages.FlightDepartsInLessThanThirtyMinutes, flight.From, flight.To);
        var sut = new FlightNotificationService(_timeProvider);

        // Act
        var result = sut.GetFlightNotificationMessage(flight);

        // Assert
        result.Should().Be(expectedMessage);
    }

    [Fact]
    public void GivenThatFlightHasAlreadyDeparted_WhenGetFlightNotificationMessageIsInvoked_ThenCorrectMessageIsReturned()
    {
        // Arrange
        var flight = new Flight
        {
            From = "Heathrow Airport",
            To = "John F. Kennedy International Airport",
            Time = new DateTime(2024, 02, 05, 15, 00, 00)
        };
        _timeProvider.SetUtcNow(new DateTime(2024, 02, 05, 15, 01, 00));
        var expectedMessage = string.Format(Messages.FlightAlreadyDeparted, flight.From, flight.To);
        var sut = new FlightNotificationService(_timeProvider);

        // Act
        var result = sut.GetFlightNotificationMessage(flight);

        // Assert
        result.Should().Be(expectedMessage);
    }
}
