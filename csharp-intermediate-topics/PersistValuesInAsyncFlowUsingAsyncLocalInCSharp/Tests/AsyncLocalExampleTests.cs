namespace Tests;

using PersistValuesInAsyncFlowUsingAsyncLocalInCSharp;

[TestClass]
public class AsyncLocalExampleTests
{
    [TestMethod]
    public async Task GivenAsyncLocalExample_WhenDoWork_AsyncValueIsOne()
    {
        await AsyncLocalExample.DoWork();

        Assert.AreEqual(0, AsyncLocalExample.AsyncLocalInt.Value);
    }
}