using DelegateApplication;
namespace ActionAndFuncDelegateTest;


public class UnitTest1
{
    [Fact]
    public void BaseDelegateTest()
    {
        const int currentAmount = 500;
        const int previousAmount = 450;
        const string expected = $"Amount difference is 50";
        OurDelegate ourDelegate = DelegateExamples.DelegateMethod;
        var actual = ourDelegate.Invoke(previousAmount, currentAmount);
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ActionDelegateTest()
    {
        const int currentAmount = 650;
        const int previousAmount = 450;
        Action<int, int> instanceOfActionDelegate = FuncAndActionDelegateExamples.ActionDelegateMethod;
        instanceOfActionDelegate.Invoke(previousAmount, currentAmount);
        Assert.True(true);
    }
    
    [Fact]
    public void FuncDelegateTest()
    {
        const int currentAmount = 600;
        const int previousAmount = 450;
        const string expected = $"Amount difference is 150";
        Func<int, int, string> instanceOfFuncDelegate = FuncAndActionDelegateExamples.FuncDelegateMethod;
        var actual = instanceOfFuncDelegate.Invoke(previousAmount, currentAmount);
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void FuncDelegateWithArrowFunctionTest()
    {
        const int currentAmount = 600;
        const int previousAmount = 450;
        const string expected = $"Amount difference is 150";
        Func<int, int, string> instanceOfFuncDelegate = (int currentAmount, int previousAmount) 
            => $"Amount difference is {currentAmount - previousAmount}";;
        var actual = instanceOfFuncDelegate.Invoke(currentAmount, previousAmount);
        Assert.Equal(expected, actual);
    }
}