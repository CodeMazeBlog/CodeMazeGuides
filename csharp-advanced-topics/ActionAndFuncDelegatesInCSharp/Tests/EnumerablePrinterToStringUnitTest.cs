using static ActionAndFuncDelegatesInCSharp.FuncDemonstrationFormatting;

namespace Tests;

public class EnumerablePrinterToStringUnitTest
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, "2, 4, 6")]
    [InlineData(new int[] { 1 }, "2")]
    [InlineData(new int[] { 1, 2, 3, -7 }, "2, 4, 6, -14")]
    public void WhenGivenNumber_GivesReversed(int[] numbers, string expectedFormat)
    {
        Func<int, string> doubler = x => (x * 2).ToString();

        EnumerablePrinter<int> printer = new() { Objects = numbers, Formatter = doubler };

        printer.ToString().ShouldBe(expectedFormat);
    }
}
