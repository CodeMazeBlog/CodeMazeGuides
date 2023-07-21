using MessagingLibrary;

namespace Tests;

public class NotifierUnitTest
{
    [Fact]
    public void WhenSmsIsPassedAsParameter_ThenSmsMustBeSent()
    {
        var notifier = new Notifier("sms"); 
        Assert.Equal("Sending SMS", notifier.NotificationResult);
    }

    [Fact]
    public void WhenEmailIsPassedAsParameter_ThenEmailMustBeSent()
    {
        var notifier = new Notifier("email");
        Assert.Equal("Sending Email", notifier.NotificationResult);
    }

    [Fact]
    public void WhenInvalidParameterIsPassed_ThenExceptionMustBeThrown()
    {
        Assert.Throws<ArgumentException>(() => new Notifier("invalid"));
    }
}