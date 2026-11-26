namespace Tests;

using PersistValuesInAsyncFlowUsingAsyncLocalInCSharp;

[TestClass]
public class AsyncLocalReferenceTypeExampleTests
{
    [TestMethod]
    public async Task GivenAsyncLocalReferenceTypeExample_WhenDoWork_ThenCallerSeesChildChangeToList()
    {
        var output = new StringWriter();
        var originalOutput = Console.Out;
        Console.SetOut(output);

        try
        {
            await AsyncLocalReferenceTypeExample.DoWork();
        }
        finally
        {
            Console.SetOut(originalOutput);
        }

        StringAssert.Contains(output.ToString(), "Added in DoWork, Added in DoSubTask");
    }
}
