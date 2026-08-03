using LocalFunctionsVsLambdaExpressionsInCSharp;

namespace Tests;

[TestClass]
public class GenericLocalFunctionsTests
{
    [TestMethod]
    [DataRow(5, 10, 10, 5)]
    [DataRow("a", "b", "b", "a")]
    public void GivenListOfTuples_WhenCallSwapElements_ElementsAreSwapped(object left, object right, object expectedLeft, object expectedRight)
    {
        GenericLocalFunctions.SwapElements(ref left, ref right);

        Assert.AreEqual(left, expectedLeft);
        Assert.AreEqual(right, expectedRight);
    }
}
