namespace UsingKeyedServicesToResolveDependencies.Tests;

public class InPersonEventServiceTests
{
    private readonly InPersonEventService _inPersonEventService;

    public InPersonEventServiceTests()
    {
        _inPersonEventService = new InPersonEventService();
    }

    [Fact]
    public void WhenStartEventIsInvoked_ThenExpectedMessageIsReturned()
    {
        const string message = "Starting the in-person event. Please turn off your phones.";

        // Act
        var result = _inPersonEventService.StartEvent();

        // Assert
        result.Should().Be(message);
    }

    [Fact]
    public void WhenEndEventIsInvoked_ThenExpectedMessageIsReturned()
    {
        const string message = "Ending the in-person event. You can turn on your phones.";

        // Act
        var result = _inPersonEventService.EndEvent();

        // Assert
        result.Should().Be(message);
    }
}