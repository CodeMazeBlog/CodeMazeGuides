namespace MessagePublisherSubscriberTests;

public class MessagePublisherSubscriberTests
{
    [Fact]
    public async Task GivenMessagePublisher1_WhenSendMessageCalled_ThenSendMessageAsyncInvoked()
    {
        //Arrange            
        Mock<IMessageService> mockMessageService = new();
        mockMessageService.Setup(x =>
        x.SendMessageAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

        //Act                        
        MessagePublisher1 messagePublisher1 = new(mockMessageService.Object);
        await messagePublisher1.SendMessagesAsync();

        //Assert            
        mockMessageService.Verify(m =>
        m.SendMessageAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(3));
    }

    [Fact]
    public async Task GivenMessagePublisher2_WhenSendMessageIsCalled_ThenSendMessageAsyncInvoked()
    {
        //Arrange
        Mock<IMessageService> mockMessageService = new();
        mockMessageService.Setup(x =>
        x.SendMessageAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

        //Act            
        MessagePublisher2 messagePublisher2 = new(mockMessageService.Object);
        await messagePublisher2.SendMessagesAsync();

        //Assert
        mockMessageService.Verify(m =>
        m.SendMessageAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(3));
    }

    [Fact]
    public async Task GivenMessageSubscriber1_WhenReceiveMessagesIsCalled_ThenReceiveMessagesWithSubscriptionAsyncInvoked()
    {
        //Arrange
        Mock<IMessageService> mockMessageService = new();
        mockMessageService.Setup(x =>
        x.ReceiveMessagesWithSubscriptionAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Action<string>>(), It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        //Act                        
        MessageSubscriber1 messageSubscriber = new(mockMessageService.Object);
        await messageSubscriber.ReceiveMessagesAsync();

        //Assert
        mockMessageService.Verify(m =>
        m.ReceiveMessagesWithSubscriptionAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Action<string>>(), It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task GivenMessageSubscriber2_WhenReceiveMessagesIsCalled_ThenReceiveMessagesWithSubscriptionAsyncInvoked()
    {
        //Arrange
        Mock<IMessageService> mockMessageService = new();
        mockMessageService.Setup(x =>
        x.ReceiveMessagesWithSubscriptionAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Action<string>>(), It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        //Act                        
        MessageSubscriber2 messageSubscriber = new(mockMessageService.Object);
        await messageSubscriber.ReceiveMessagesAsync();

        //Assert
        mockMessageService.Verify(m =>
        m.ReceiveMessagesWithSubscriptionAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Action<string>>(), It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task GivenMessageSubscriber3_WhenReceiveMessagesIsCalled_ThenReceiveMessagesWithSubscriptionAsyncInvoked()
    {
        //Arrange
        Mock<IMessageService> mockMessageService = new();
        mockMessageService.Setup(x =>
        x.ReceiveMessagesWithSubscriptionAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Action<string>>(), It.IsAny<int>()))
            .Returns(Task.CompletedTask);

        //Act                        
        MessageSubscriber3 messageSubscriber = new(mockMessageService.Object);
        await messageSubscriber.ReceiveMessagesAsync();

        //Assert
        mockMessageService.Verify(m =>
        m.ReceiveMessagesWithSubscriptionAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Action<string>>(), It.IsAny<int>()), Times.Once);
    }
}