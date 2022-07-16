using static ActionAndFuncDelegatesInCSharp.FuncDemonstrationFormatting;

namespace Tests;

public class EnumerablePrinterPrintUnitTest : IDisposable
{
    public void Dispose()
    {
        var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, "2, 4, 6")]
    [InlineData(new int[] { 1 }, "2")]
    [InlineData(new int[] { 1, 2, 3, -7 }, "2, 4, 6, -14")]
    public void WhenGivenNumbers_PrintsDoubledCommaSeparated(int[] numbers, string expectedFormat)
    {
        Func<int, string> doubler = x => (x * 2).ToString();

        EnumerablePrinter<int> printer = new() { Objects = numbers, Formatter = doubler };

        using StringWriter sw = new();
        Console.SetOut(sw);

        printer.Print();

        sw.ToString().ShouldBe(expectedFormat);
    }
}
