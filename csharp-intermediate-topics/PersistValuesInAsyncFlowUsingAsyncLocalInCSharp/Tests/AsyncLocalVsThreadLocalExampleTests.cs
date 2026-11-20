namespace Tests;

using PersistValuesInAsyncFlowUsingAsyncLocalInCSharp;

[TestClass]
public class AsyncLocalVsThreadLocalExampleTests
{
    [TestMethod]
    public async Task GivenAsyncLocalVsThreadLocalExample_WhenDoWork_ThenOnlyAsyncLocalFlowsUntilSuppressed()
    {
        var output = new StringWriter();
        var originalOutput = Console.Out;
        Console.SetOut(output);

        try
        {
            await AsyncLocalVsThreadLocalExample.DoWork();
        }
        finally
        {
            Console.SetOut(originalOutput);
        }

        StringAssert.Contains(output.ToString(), "New thread, AsyncLocal: Set in DoWork, ThreadLocal: null");
        StringAssert.Contains(output.ToString(), "Task.Run with suppressed flow, AsyncLocal: null");
    }
}
