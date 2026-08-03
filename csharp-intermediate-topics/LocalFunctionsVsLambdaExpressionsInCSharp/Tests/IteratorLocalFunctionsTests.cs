using LocalFunctionsVsLambdaExpressionsInCSharp;

namespace Tests;

[TestClass]
public class IteratorLocalFunctionsTests
{
    [TestMethod]    
    public void GivenListIntegers_WhenCallIntegersToAbsoluteValue_ListofAbsoluteValuesIsReturned()
    {
        var numberList = new List<int> { 1, -1, 0, -2, 3, -5 };
        var expected = new List<int> { 1, 1, 0, 2, 3, 5 };

        var actual = IteratorLocalFunctions.IntegersToAbsoluteValue(numberList).ToList();

        CollectionAssert.AreEqual(expected, actual);
    }
}