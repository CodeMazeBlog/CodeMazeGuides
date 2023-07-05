public partial  class ActionDelegateInCSharp
{
     public void ExecuteWithoutParameterUsingAnonymousMethod()
    {
        Action showMethodUsingAnonymousMethod = delegate(){nameDisplay.DisplayValue();};
        showMethodUsingAnonymousMethod();
    }

    public void ExecuteWithParameterUsingAnonymousMethod()
    {
        Action<string> showMethodWithParameterUsingAnonymousMethod 
            = delegate(string name){nameDisplay.DisplayValue(name);};
        showMethodWithParameterUsingAnonymousMethod("Code Maze from Parameters using Anonymous Method");
    }
}