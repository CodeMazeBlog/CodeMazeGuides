using ActionAndFuncDelegates.Logic;

public partial class FuncDelegateInCSharp
{
    public readonly Counter counter;
    public FuncDelegateInCSharp(Counter counter)
    {
        this.counter = counter;
    }

    public bool ExecuteWithoutParameter()
    {
        Func<bool> checkEvenNumberMethod = counter.IsCountEven;
        return checkEvenNumberMethod();
    }

    public bool ExecuteWithParameter()
    {
        Func<int, bool> greaterthanMethodFromParameter = counter.IsCountGreaterThanValue;
        return greaterthanMethodFromParameter(20);
        
    }

}