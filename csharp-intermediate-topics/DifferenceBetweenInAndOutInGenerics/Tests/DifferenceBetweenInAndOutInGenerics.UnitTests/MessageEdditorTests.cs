namespace DifferenceBetweenInAndOutInGenerics.UnitTests;

using MessageEditor;
using Messages;

public class MessageEdditorTests
{
    [Fact]
    public void WhenEditAndCopyOriginalMessage_ThenOutputMessageIsANewObject()
    {
        // Arrange
        var message = new SubMessage();
        IMessageEdditor<SubMessage> messageEditor = new MessageEdditor<SubMessage>();

        // Act
        var editedCopy = messageEditor.EditAndCopyOriginalMessage(message);

        // Assert
        Assert.NotEqual(message, editedCopy);
    }
}
