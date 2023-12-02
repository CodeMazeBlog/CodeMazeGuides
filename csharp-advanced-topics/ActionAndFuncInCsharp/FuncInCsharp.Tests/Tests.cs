
namespace FuncInCsharp.Tests;

public class Tests
{
    [Fact]
    public void WhenRecalculatedWithAddFiveFunc_ThenArrayElementsMustBeIncreasedByFive()
    {
        var foo = new Foo(0, 10, 20);
        foo.Recalculate(AddFive);

        Assert.Equal(new[] {5, 15, 25}, foo.Values);
    }

    private static int AddFive(int value) => value + 5;
}
