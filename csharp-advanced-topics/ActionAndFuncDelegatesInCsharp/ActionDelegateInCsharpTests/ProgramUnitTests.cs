using ActionDelegateInCsharp;

namespace ActionDelegateInCsharpTests;

public class ProgramTests
{
    [Fact]
    public void GivenCallbackMethod_WhenExecuteWithActionCallbackCalled_ThenCallbackMethodInvoked()
    {
        // Given
        bool isCallbackInvoked = false;
        Action callback = () => { isCallbackInvoked = true; };

        // When
        Program.Execute(callback);

        // Then
        Assert.True(isCallbackInvoked);
    }

    [Fact]
    public void GivenCallbackMethodWithOneStringArgument_WhenExecuteWithActionStringCallbackCalled_ThenCallbackMethodInvokedWithArgument()
    {
        // Given
        string expectedMessage = "Hello World!";
        string? actualMessage = null;
        Action<string> callback = message => { actualMessage = message; };

        // When
        Program.Execute(callback);

        // Then
        Assert.Equal(expectedMessage, actualMessage);
    }

    [Fact]
    public void GivenCallbackMethodWithTwoStringArguments_WhenExecuteWithActionStringStringCallbackCalled_ThenCallbackMethodInvokedWithArguments()
    {
        // Given
        string expectedGreeting = "Hello";
        string expectedName = "World";
        string? actualGreeting = null;
        string? actualName = null;
        Action<string, string> callback = (greeting, name) =>
        {
            actualGreeting = greeting;
            actualName = name;
        };

        // When
        Program.Execute(callback);

        // Then
        Assert.Equal(expectedGreeting, actualGreeting);
        Assert.Equal(expectedName, actualName);
    }
}
