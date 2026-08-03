namespace Tests;

using PersistValuesInAsyncFlowUsingAsyncLocalInCSharp;

[TestClass]
public class AsyncLocalNotifyExampleTests
{
    [TestMethod]
    public async Task GivenAsyncLocalNotifyExample_WhenDoWork_AsyncValueIsOne()
    {
        await AsyncLocalNotifyExample.DoWork();

        Assert.IsNull(AsyncLocalNotifyExample.AsyncLocalString.Value);
    }
}