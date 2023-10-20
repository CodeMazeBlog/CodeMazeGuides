namespace ActionAndFuncDelegates.Tests;

[TestClass]
public class SendNotificationTests
{
    [TestMethod]
    public void WhenSendNotificationCalled_DelegateInvocationListNotEmpty()
    {
        var sendNotificationAction = new SendNotification().SendNotificationAction;

        var invocationList = sendNotificationAction.GetInvocationList();

        Assert.AreEqual(invocationList.Length, 1);
    }
}
