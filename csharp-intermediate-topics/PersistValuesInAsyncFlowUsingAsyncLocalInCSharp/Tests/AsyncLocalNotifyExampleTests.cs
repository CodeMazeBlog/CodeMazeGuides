namespace Tests;

using PersistValuesInAsyncFlowUsingAsyncLocalInCSharp;

[TestClass]
public class AsyncLocalNotifyExampleTests
{
    [TestMethod]
    public async Task GivenAsyncLocalNotifyExample_WhenDoWork_ThenCallerKeepsNullValue()
    {
        await AsyncLocalNotifyExample.DoWork();

        Assert.IsNull(AsyncLocalNotifyExample.AsyncLocalString.Value);
    }
}