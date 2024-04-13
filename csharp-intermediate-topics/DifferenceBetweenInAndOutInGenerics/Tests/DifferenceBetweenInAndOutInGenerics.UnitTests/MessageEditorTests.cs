namespace DifferenceBetweenInAndOutInGenerics.UnitTests;

using MessageEditor;
using Messages;

public class MessageEditorTests
{
    [Fact]
    public void WhenEditAndCopyOriginalMessage_ThenOutputMessageIsANewObject()
    {
        // Arrange
        var message = new SubMessage();
        IMessageEditor<SubMessage> messageEditor = new MessageEditor<SubMessage>();

        // Act
        var editedCopy = messageEditor.EditAndCopyOriginalMessage(message);

        // Assert
        Assert.NotEqual(message, editedCopy);
    }
}
