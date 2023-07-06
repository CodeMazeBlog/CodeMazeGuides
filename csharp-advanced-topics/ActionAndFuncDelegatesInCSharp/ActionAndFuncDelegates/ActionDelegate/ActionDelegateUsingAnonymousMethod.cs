public partial  class ActionDelegateInCSharp
{
     public void ExecuteWithoutParameterUsingAnonymousMethod()
    {
        Action incrementMethodUsingAnonymousMethod = delegate(){counter.Increment();};
        incrementMethodUsingAnonymousMethod();
    }

    public void ExecuteWithParameterUsingAnonymousMethod()
    {
        Action<int> incrementMethodWithParameterUsingAnonymousMethod
            = delegate(int value){counter.IncrementBy(value);};
        incrementMethodWithParameterUsingAnonymousMethod(20);
    }
}