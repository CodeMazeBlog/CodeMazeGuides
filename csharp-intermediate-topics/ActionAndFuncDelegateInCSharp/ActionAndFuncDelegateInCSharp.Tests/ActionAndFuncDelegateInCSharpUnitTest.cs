using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class ActionAndFuncTest
{
    private string expected =
        $"With Action{Environment.NewLine}"
        + $"5{Environment.NewLine}"
        + $"6{Environment.NewLine}"
        + $"Without Action{Environment.NewLine}"
        + $"5{Environment.NewLine}"
        + $"6{Environment.NewLine}"
        + $"With Func{Environment.NewLine}"
        + $"5{Environment.NewLine}"
        + $"6{Environment.NewLine}"
        + $"Without Func{Environment.NewLine}"
        + $"5{Environment.NewLine}"
        + $"6";

    [TestMethod]
    public void ActionTest()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        ActionAndFuncDelegateInCSharp.Program.Main();

        // Assert
        var result = sw.ToString().Trim();
        Assert.AreEqual(expected, result);
    }
}
