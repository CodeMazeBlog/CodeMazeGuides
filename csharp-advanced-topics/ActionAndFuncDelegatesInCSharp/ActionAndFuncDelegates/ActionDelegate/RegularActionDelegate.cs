using ActionAndFuncDelegates.Logic;

public partial  class ActionDelegateInCSharp
{
    public readonly Counter counter;
    public ActionDelegateInCSharp(Counter counter)
    {
        this.counter = counter;
    }

    public void ExecuteWithoutParameter()
    {
        Action incrementMethod = counter.Increment;
        incrementMethod();
    }

    public void ExecuteWithParameter()
    {
        Action<int> incrementMethodWithParameter = counter.IncrementBy;
        incrementMethodWithParameter(20);
    }

}