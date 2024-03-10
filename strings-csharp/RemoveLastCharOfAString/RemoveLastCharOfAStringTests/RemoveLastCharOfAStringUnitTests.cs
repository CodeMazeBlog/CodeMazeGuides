using RemoveLastCharOfAString;

namespace RemoveLastCharOfAStringTests;

[TestClass]
public class RemoveLastCharOfAStringUnitTests
{
    private TechniquesToRemoveLastChar methodInstances = new();
    private const string inputString = "2147483647";
    private const string outputString = "214748364";

    [TestMethod]
    public void GivenAString_WhenSubstringUsed_ThenVerifyLastCharRemoved()
    {
        var actualString = methodInstances.RemoveLastCharUsingSubstring(inputString);

        Assert.AreEqual(outputString, actualString);
    }

    [TestMethod]
    public void GivenAString_WhenLINQUsed_ThenVerifyLastCharRemoved()
    {
        var actualString = methodInstances.RemoveLastCharUsingLinq(inputString);

        Assert.AreEqual(outputString, actualString);
    }

    [TestMethod]
    public void GivenAString_WhenRemoveMethodInvoked_ThenVerifyLastCharRemoved()
    {
        var actualString = methodInstances.RemoveLastCharUsingRemove(inputString);

        Assert.AreEqual(outputString, actualString);
    }

    [TestMethod]
    public void GivenAString_WhenReadOnlySpanUsed_ThenVerifyLastCharRemoved()
    {
        var actualString = methodInstances.RemoveLastCharUsingSpan(inputString);

        Assert.AreEqual(outputString, actualString);
    }

    [TestMethod]
    public void GivenAString_WhenStringBuilderUsed_ThenVerifyLastCharRemoved()
    {
        var actualString = methodInstances.RemoveLastCharUsingStringBuilder(inputString);

        Assert.AreEqual(outputString, actualString);
    }
}