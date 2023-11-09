namespace UsingKeyedServicesToResolveDependencies.Tests;

public class OnlineEventServiceTests
{
    private readonly OnlineEventService _onlineEventService;

    public OnlineEventServiceTests()
    {
        _onlineEventService = new OnlineEventService();
    }

    [Fact]
    public void WhenStartEventIsInvoked_ThenExpectedMessageIsReturned()
    {
        const string message = "Starting the online event. Please turn off your microphones.";

        // Act
        var result = _onlineEventService.StartEvent();

        // Assert
        result.Should().Be(message);
    }

    [Fact]
    public void WhenEndEventIsInvoked_ThenExpectedMessageIsReturned()
    {
        const string message = "Ending the online event. You can turn on your microphones.";

        // Act
        var result = _onlineEventService.EndEvent();

        // Assert
        result.Should().Be(message);
    }
}
