using static ActionAndFuncDelegatesInCSharp.FuncDemonstrationFormatting;

namespace Tests;

public class ObjectPrinterToStringUnitTest
{
    [Theory]
    [InlineData(1005, "5001")]
    [InlineData(1000, "0001")]
    [InlineData(8, "8")]
    public void WhenGivenNumber_GivesReversed(int number, string expectedFormat)
    {
        Func<int, string> reverser = x => new string(x.ToString().Reverse().ToArray());

        ObjectPrinter<int> reversePrinter = new() { Object = number, Formatter = reverser };

        reversePrinter.ToString().ShouldBe(expectedFormat);
    }
}
