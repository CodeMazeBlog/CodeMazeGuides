namespace UsingKeyedServicesToResolveDependencies.Tests;

public class InPersonEventProducerTests
{
    private readonly IEventService _eventService;
    private readonly InPersonEventProducer _inPersonEventProducer;

    public InPersonEventProducerTests()
    {
        _eventService = Substitute.For<IEventService>();
        _inPersonEventProducer = new InPersonEventProducer(_eventService);
    }

    [Fact]
    public void WhenProduceEventIsInvoked_ThenExpectedMethodAreCalled()
    {
        // Act
        var result = _inPersonEventProducer.ProduceEvent();

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
