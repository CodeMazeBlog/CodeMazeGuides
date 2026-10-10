using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwitchCaseExpression;

namespace Tests;

[TestClass]
public class UnitTestSwitch
{
    private const string PleasantWeather = "It is a pleasant day";
    private const string HotWeather = "It is hot today";
    private const string VeryHotWeather = "It is very hot today";
    private const string NoWeatherReport = "No weather report";

    private static string GetExpectedOutputForTest(int temp)
    {
        switch (temp)
        {
            case 20:
            case 22:
            case 24:
                return PleasantWeather;
            case 30:
                return HotWeather;
            case 35:
                return VeryHotWeather;
            default:
                return NoWeatherReport;
        }
    }

    [TestMethod]
    [DataRow(20)]
    [DataRow(22)]
    [DataRow(24)]
    [DataRow(30)]
    [DataRow(35)]
    [DataRow(99)]
    public void WhenMultipleCasesHaveSameResult(int temp)
    {
        Assert.AreEqual(GetExpectedOutputForTest(temp), Program.SubMultipleCaseResults(temp));
    }

    [TestMethod]
    [DataRow(100, "The value is between 50 and 150")]
    [DataRow(150, "The value is between 50 and 150")]
    [DataRow(151, "The value is between 150 and 200")]
    [DataRow(200, "The value is between 150 and 200")]
    [DataRow(201, "The number is not within the given range.")]
    public void WhenMultipleCasesUseRangePattern(int value, string expected)
    {
        Assert.AreEqual(expected, Program.SubMultipleCaseWithRangePattern(value));
    }

    [TestMethod]
    public void WhenGuardMatchesEvenValue()
    {
        Assert.AreEqual("An even value between 50 and 150", Program.SubMultipleCaseWithGuard(100));
    }

    [TestMethod]
    public void WhenGuardMatchesOddValue()
    {
        Assert.AreEqual("An odd value between 50 and 150", Program.SubMultipleCaseWithGuard(101));
    }

    [TestMethod]
    [DataRow(20)]
    [DataRow(22)]
    [DataRow(24)]
    [DataRow(30)]
    [DataRow(35)]
    public void WhenMultipleCaseWithListValues(int temp)
    {
        Assert.AreEqual(GetExpectedOutputForTest(temp), Program.SubMultipleCaseWithListValues(temp));
    }

    [TestMethod]
    [DataRow(20)]
    [DataRow(22)]
    [DataRow(24)]
    [DataRow(30)]
    [DataRow(35)]
    public void WhenSwitchCaseWithOrPattern(int temp)
    {
        Assert.AreEqual(GetExpectedOutputForTest(temp), Program.SubMultipleCaseWithOrPattern(temp));
    }

    [TestMethod]
    [DataRow(20)]
    [DataRow(22)]
    [DataRow(24)]
    [DataRow(30)]
    [DataRow(35)]
    public void WhenSwitchCaseWithExtensionMethod(int temp)
    {
        Assert.AreEqual(GetExpectedOutputForTest(temp), Program.SubMultipleCaseWithExtension(temp));
    }
}
