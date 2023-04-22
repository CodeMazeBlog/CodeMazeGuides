using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Text;
using Xunit;

namespace Tests;

public class DelegateTest
{
    static readonly StringWriter bufferWriter = new StringWriter();

    public DelegateTest()
    {
        StringBuilder sb = bufferWriter.GetStringBuilder();
        sb.Remove(0, sb.Length);

        Console.SetOut(bufferWriter);
    }

    [Fact]
    public void WhenSampleAction1_ThenWriteConsole()
    {
        var delegatesSample = new Delegates();

        delegatesSample.SampleAction_1();

        string bufferOutput = bufferWriter?.ToString() ?? string.Empty;
        Assert.Equal($"Sum of 10 and 20 is 30{Environment.NewLine}", bufferOutput);
    }

    [Fact]
    public void WhenSampleAction2_ThenWriteConsole()
    {
        var delegatesSample = new Delegates();

        delegatesSample.SampleAction_2();

        string bufferOutput = bufferWriter?.ToString() ?? string.Empty;
        Assert.Equal($"The Double of 10 is 20{Environment.NewLine}", bufferOutput);
    }

    [Fact]
    public void WhenSampleFunc1_ThenWriteConsole()
    {
        var delegatesSample = new Delegates();

        delegatesSample.SampleFunc_1();

        string bufferOutput = bufferWriter?.ToString() ?? string.Empty;
        Assert.Equal($"Func Double result 4{Environment.NewLine}", bufferOutput);
    }

    [Fact]
    public void WhenSampleFunc2_ThenWriteConsole()
    {
        var delegatesSample = new Delegates();

        delegatesSample.SampleFunc_2();

        string bufferOutput = bufferWriter?.ToString() ?? string.Empty;
        Assert.Equal($"Func TripleDelegate with Argument 2 is 6{Environment.NewLine}", bufferOutput);
    }
}
