using static ActionAndFuncDelegatesInCSharp.FuncDemonstrationMap;

namespace Tests;

public class SumABWithSimpleTextNumberObjectUnitTest
{
    [Theory]
    [InlineData(1, 2, 3, -1, -2, "5", 8)]
    [InlineData(1, 2, 3, 0, -2, "1", 5)]
    [InlineData(1, 2, 3, -1, 0, "3", 8)]
    public void WhenSuppliedWithABAndText_GivesExpectedSum(int ax, int ay, int az, int bx, int by, string numText, int expected)
    {
        A a = new() { X = ax, Y = ay, Z = az };
        B b = new() { X = bx, Y = by };
        SimpleTextNumberObject simpleTextNumberObject = new() { TextValue = numText };

        ComplexObject complexObject = new() { A = a, B = b, SimpleTextNumberObject = simpleTextNumberObject };

        FuncDemonstrationMap demo = new();

        int result = demo.SumABWithSimpleTextNumberObject(complexObject);

        result.ShouldBe(expected);
    }
}
