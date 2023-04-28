using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace ActionAndFuncDelegateInCSharp.Test;

public sealed class FuncDelegateTest
{
    int Substraction(int x, int y)
    {
        return x - y;
    }

    [Fact]
    public void IsValid_SubsctractCalculation_ReturnEqual()
    {
        Func<int, int, int> substract = Substraction;
        int calculation = substract(40, 30);

        Assert.Equal(calculation, 10);
    }

    [Fact]
    public void IsNotValid_SubsctractCalculation_ReturnNotEqual()
    {
        Func<int, int, int> substract = Substraction;
        int calculation = substract(40, 30);

        Assert.NotEqual(calculation, 16);
    }

    [Fact]
    public void IsValid_SubsctractCalculation_ReturnTrue()
    {
        Func<int, int, int> substract = Substraction;
        int calculation = substract(40, 30);

        bool result = calculation == 10;

        Assert.True(result);
    }

    [Fact]
    public void IsNotValid_SubsctractCalculation_ReturnFalse()
    {
        Func<int, int, int> substract = Substraction;
        int calculation = substract(40, 30);

        bool result = calculation == 60;

        Assert.False(result);
    }
}
