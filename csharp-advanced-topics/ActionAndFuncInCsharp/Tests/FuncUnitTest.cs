using FuncInCsharp;

namespace Tests;

public class FuncUnitTest
{
    [Fact]
    public void WhenRecalculatedWithAddFiveFunc_ThenArrayElementsMustBeIncreasedByFive()
    {
        var values = new[] { 0, 10, 20 };

        ArrayHelper.Recalculate(values, (value) => value + 5);

        Assert.Equal(new[] { 5, 15, 25 }, values);
    }

    [Fact]
    public void WhenRecalculatedWithDoubleFunc_ThenArrayElementsMustBeDoubled()
    {
        var values = new[] { 0, 10, 20 };

        ArrayHelper.Recalculate(values, (value) => value * 2);

        Assert.Equal(new[] { 0, 20, 40 }, values);
    }
}
