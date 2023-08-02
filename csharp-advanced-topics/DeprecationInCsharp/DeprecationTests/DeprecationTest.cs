
namespace DeprecationTests;

[TestClass]
public class DeprecationTest
{
    private const string originalStr = "Hello, World!";
    private const string expectedResult = "!dlroW ,olleH";
    [TestMethod]
    public void GivenInputString_WhenReverseString_Deprecated_ThenReturnReversedString()
    {
        var input = originalStr;

        var reversed = StringUtils.ReverseString(input);

        Assert.AreEqual(expectedResult, reversed);
    }

    [TestMethod]
    public void GivenInputString_WhenReverseStringV2_ThenReturnReversedString()
    {
        var input = originalStr;

        var reversedV2 = StringUtils.ReverseStringV2(input);

        Assert.AreEqual(expectedResult, reversedV2);
    }

}
