namespace MessageSenderTests;

public class MessageSenderReceiverTests
{
    [Fact]
    public async Task GivenMessageSender_WhenMessageSenderIsCalled_ThenMessageSentToQueueAsyncInvoked()
    {
        //Arrange
        Mock<IMessageService> mockMessageService = new();
        mockMessageService.Setup(x =>
            x.SendMessageAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

        //Act
        MessageSender messageSender = new(mockMessageService.Object);
        await messageSender.SendMessagesAsync();

        //Assert            
        mockMessageService.Verify(m =>
            m.SendMessageAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(3));
    }

    [Fact]
    public async Task GivenMessageReceiver_WhenReceiverIsCalled_ThenMessageReceivedFromQueueAsyncInvoked()
    {
        //Arrange          
        Mock<IMessageService> mockMessageService = new();
        mockMessageService.Setup(x =>
            x.ReceiveMessagesFromQueueAsync(It.IsAny<string>(), It.IsAny<Action<string>>(), It.IsAny<int>())).Returns(Task.CompletedTask);

        //Act                        
        MessageReceiver messageReceiver = new(mockMessageService.Object);
        await messageReceiver.ReceiveMessagesAsync();

        //Assert            
        mockMessageService.Verify(m =>
            m.ReceiveMessagesFromQueueAsync(It.IsAny<string>(), It.IsAny<Action<string>>(), It.IsAny<int>()), Times.Once);
    }
}