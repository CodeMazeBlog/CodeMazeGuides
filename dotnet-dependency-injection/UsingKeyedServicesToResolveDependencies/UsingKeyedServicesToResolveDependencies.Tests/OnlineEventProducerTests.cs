namespace UsingKeyedServicesToResolveDependencies.Tests;

public class OnlineEventProducerTests
{
    private readonly IEventService _eventService;
    private readonly OnlineEventProducer _onlineEventProducer;

    public OnlineEventProducerTests()
    {
        _eventService = Substitute.For<IEventService>();
        _onlineEventProducer = new OnlineEventProducer(_eventService);
    }

    [Fact]
    public void WhenProduceEventIsInvoked_ThenExpectedMethodAreCalled()
    {
        // Act
        var result = _onlineEventProducer.ProduceEvent();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();

        _eventService
            .Received(1)
            .StartEvent();

        _eventService
            .Received(1)
            .EndEvent();
    }
}
