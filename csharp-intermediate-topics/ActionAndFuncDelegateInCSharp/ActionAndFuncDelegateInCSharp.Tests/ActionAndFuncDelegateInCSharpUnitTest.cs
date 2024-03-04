using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class ActionAndFuncTest
{
    private readonly string _expected =
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
    public void GivenActionAndFunc_WhenMainMethodIsCalled_ThenReturnExpectedOutput()
    {
        // Given
        using var sw = new StringWriter();
        Console.SetOut(sw);

        // When
        ActionAndFuncDelegateInCSharp.Program.Main();

        var result = sw.ToString().Trim();

        // Assert
        Assert.AreEqual(_expected, result);
    }
}
