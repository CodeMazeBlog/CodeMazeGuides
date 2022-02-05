using NUnit.Framework;
using ActionAndFuncDelegates;

namespace Tests;

public class FuncClassUnitTest
{
    [Test]
    public void GivenThatWeAdd2_WhenNumberIs4_ThenReturn6()
    {
        FuncClass.Manipulate = AddTwo;

        Assert.IsTrue(6 == FuncClass.Manipulate(4));
    }

    public void GivenThatWeSubtract2_WhenNumberIs10_ThenReturn8()
    {
        FuncClass.Manipulate = SubtractTwo;

        Assert.IsTrue(8 == FuncClass.Manipulate(10));
    }

    public void GivenThatWeMultiplyBy2_WhenNumberIs32_ThenReturn64()
    {
        FuncClass.Manipulate = MultiplyByTwo;

        Assert.IsTrue(64 == FuncClass.Manipulate(32));
    }

    public void GivenThatWeDivideBy2_WhenNumberIs4_ThenReturn2()
    {
        FuncClass.Manipulate = DivideByTwo;

        Assert.IsTrue(2 == FuncClass.Manipulate(4));
    }

    private int AddTwo(int number)
    {
        return number + 2;
    }

    private int SubtractTwo(int number)
    {
        return number - 2;
    }

    private int MultiplyByTwo(int number)
    {
        return number * 2;
    }

    private int DivideByTwo(int number)
    {
        return number / 2;
    }
}