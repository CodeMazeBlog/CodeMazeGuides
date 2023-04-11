using System.Text;
using FuncAndActionDelegatesInCSharp;

namespace Tests;

public class ActionExampleTests
{
    [Fact]
    public void GivenNonEmptyList_WhenCallingProcessStringsUsingToUpper_ThenResultListIsUpperCase()
    {
        var input = new List<string> { "apple", "banana", "cherry" };
        var expected = "APPLE" + Environment.NewLine + "BANANA" + Environment.NewLine + "CHERRY" + Environment.NewLine;

        var sb = new StringBuilder();
        Action<string> captureOutput = x => sb.AppendLine(x.ToUpper());

        ActionExample.ProcessStringsUsingAction(input, captureOutput);

        var result = sb.ToString();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenEmptyList_WhenCallingProcessStringsUsingToUpper_ThenNoOutput()
    {
        var input = new List<string>();
        var expected = string.Empty;

        var sb = new StringBuilder();
        Action<string> captureOutput = x => sb.AppendLine(x.ToUpper());

        ActionExample.ProcessStringsUsingAction(input, captureOutput);

        var result = sb.ToString();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void WhenCallingProcessStringsUsingAddPrefix_ThenOutputHasPrefix()
    {
        var input = new List<string> { "apple", "banana", "cherry" };
        var expected = "fruit: apple" + Environment.NewLine + "fruit: banana" + Environment.NewLine + "fruit: cherry" + Environment.NewLine;

        var sb = new StringBuilder();
        Action<string> captureOutput = x => sb.AppendLine($"fruit: {x}");

        ActionExample.ProcessStringsUsingAction(input, captureOutput);

        string result = sb.ToString();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenNonEmptyList_WhenProcessingStringsToCountLength_ThenLengthListIsReturned()
    {
        var input = new List<string> { "apple", "banana", "cherry" };
        var expected = new List<int> { 5, 6, 6 };

        var result = new List<int>();
        Action<string> captureOutput = x => result.Add(x.Length);

        ActionExample.ProcessStringsUsingAction(input, captureOutput);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenNullList_WhenProcessingStrings_ThenNullReferenceExceptionThrown()
    {
        List<string> input = null;
        
        Action<string> captureOutput = x => {x.ToLower();};

        Assert.Throws<NullReferenceException>(()=>ActionExample.ProcessStringsUsingAction(input, captureOutput));
    }
}