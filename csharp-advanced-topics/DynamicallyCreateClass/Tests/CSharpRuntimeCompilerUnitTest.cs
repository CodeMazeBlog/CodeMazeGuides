using Microsoft.VisualStudio.TestTools.UnitTesting;

using WithCSharpCompilation;

namespace Tests;

[TestClass]
public class CSharpRuntimeCompilerUnitTest
{
    [TestMethod]
    public void GivenRawCodeWithAggregationFunction_WhenExecutedOnArgs_ThenGetAggregatedResult()
    {
        var code =
            @"
            using System.Linq;

            namespace CSharpRuntimeCompilation
            {
                public class Aggregator
                {
                    public int Sum(params int[] nums)
                    {
                        return nums.Sum();
                    }
                }
            }";
        var runtimeCompiler = new CSharpRuntimeCompiler(code);
        var aggregator = runtimeCompiler.GetInstance("CSharpRuntimeCompilation.Aggregator");

        var result = aggregator?.Sum(1, 2, 3);

        Assert.AreEqual(6, result);
    }
}
