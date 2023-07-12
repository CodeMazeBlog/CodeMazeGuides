using MessagingLibrary;

namespace Tests;

public class NotifierUnitTest
{
    [Fact]
    public void WhenSmsIsPassedAsParameter_ThenSmsMustBeSent()
    {
        var notifier = new Notifier("sms");
        Assert.Equal("Sending SMS", notifier.NotificationHandler);
    }

    [Fact]
    public void WhenEmailIsPassedAsParameter_ThenEmailMustBeSent()
    {
        var notifier = new Notifier("email");
        Assert.Equal("Sending Email", notifier.NotificationHandler);
    }
}