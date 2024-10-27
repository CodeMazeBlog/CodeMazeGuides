using MassTransit;
using NSubstitute;
using MessagingComparisons.Domain;

namespace MessagingComparisons.MassTransit.Tests;

public class MassTransitStrategyTests
{
    private IBus _bus;
    private ISendEndpoint _sendEndpoint;
    private ISendEndpointProvider _sendEndpointProvider;
    private Message _message;

    [SetUp]
    public void Setup()
    {
        _message = new Message
        {
            MessageId = Guid.NewGuid().ToString(),
            Content = "Message send using MassTransit"
        };
        
        _bus = Substitute.For<IBus>();
        _sendEndpoint = Substitute.For<ISendEndpoint>();
        _sendEndpointProvider = Substitute.For<ISendEndpointProvider>();
        _sendEndpointProvider.GetSendEndpoint(Arg.Any<Uri>()).Returns(_sendEndpoint);
    }
    
    [Test]
    public async Task GivenMassTransitMessageBus_WhenSendMessageAsync_ThenPublishIsCalled()
    {
        var sut = new MassTransitStrategy(_bus, _sendEndpointProvider);
        
        await sut.SendMessageAsync(_message);

        await _bus.Received(1).Publish(_message);
    }
    
    [Test]
    public async Task GivenMassTransitMessageBus_WhenSendMessageAsyncWithQueueName_ThenPublishIsCalled()
    {
        var sut = new MassTransitStrategy(_bus, _sendEndpointProvider);
        
        await sut.SendMessageAsync(_message, "queue:TestQueue");

        await _sendEndpointProvider.Received(1).GetSendEndpoint(Arg.Any<Uri>());
        await _sendEndpoint.Received(1).Send(_message);
    }
}