using RemoveLastCharOfAString;

namespace RemoveLastCharOfAStringTests;

[TestClass]
public class RemoveLastCharOfAStringUnitTests
{
    private readonly TechniquesToRemoveLastChar _methodInstances = new();
    private const string OutputString = "214748364";
    private const string InputString = OutputString + "7";

    [TestMethod]
    public void GivenAString_WhenSubstringUsed_ThenVerifyLastCharRemoved()
    {
        var actualString = _methodInstances.RemoveLastCharUsingSubstring(InputString);

        Assert.AreEqual(OutputString, actualString);
    }

    [TestMethod]
    public void GivenAString_WhenLINQUsed_ThenVerifyLastCharRemoved()
    {
        var actualString = _methodInstances.RemoveLastCharUsingLinq(InputString);

        Assert.AreEqual(OutputString, actualString);
    }

    [TestMethod]
    public void GivenAString_WhenRemoveMethodInvoked_ThenVerifyLastCharRemoved()
    {
        var actualString = _methodInstances.RemoveLastCharUsingRemove(InputString);

        Assert.AreEqual(OutputString, actualString);
    }

    [TestMethod]
    public void GivenAString_WhenReadOnlySpanUsed_ThenVerifyLastCharRemoved()
    {
        var actualString = _methodInstances.RemoveLastCharUsingSpan(InputString);

        Assert.AreEqual(OutputString, actualString);
    }

    [TestMethod]
    public void GivenAString_WhenStringBuilderUsed_ThenVerifyLastCharRemoved()
    {
        var actualString = _methodInstances.RemoveLastCharUsingStringBuilder(InputString);

        Assert.AreEqual(OutputString, actualString);
    }

    [TestMethod]
    public void GivenAString_WhenReturnedAsSpanUsed_ThenVerifyLastCharRemoved()
    {
        var actualSpan = _methodInstances.RemoveLastCharAsSpan(InputString);

        Assert.AreEqual(OutputString, actualSpan.ToString());
    }
}