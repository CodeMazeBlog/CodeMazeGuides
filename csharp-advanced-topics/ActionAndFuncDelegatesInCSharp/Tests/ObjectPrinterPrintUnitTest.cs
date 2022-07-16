using static ActionAndFuncDelegatesInCSharp.FuncDemonstrationFormatting;

namespace Tests;

public class ObjectPrinterPrintUnitTest : IDisposable
{
    public void Dispose()
    {
        var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }

    [Theory]
    [InlineData(1005, "5001")]
    [InlineData(1000, "0001")]
    [InlineData(8, "8")]
    public void WhenGivenNumber_PrintsReversed(int number, string expectedFormat)
    {
        Func<int, string> reverser = x => new string(x.ToString().Reverse().ToArray());

        ObjectPrinter<int> reversePrinter = new() { Object = number, Formatter = reverser };

        using StringWriter sw = new();
        Console.SetOut(sw);

        reversePrinter.Print();

        sw.ToString().ShouldBe(expectedFormat);
    }
}
