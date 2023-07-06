public partial class FuncDelegateInCSharp
{
    public bool ExecuteWithoutParameterUsingAnonymousMethod()
    {
        Func<bool> checkEvenNumberMethodUsingAnonymousMethod
                =  delegate(){return counter.IsCountEven();} ;
         return checkEvenNumberMethodUsingAnonymousMethod();
    }

    public bool ExecuteWithParameterUsingAnonymousMethod()
    {
       Func<int, bool> greaterthanMethodFromParameterUsingAnonymousMethod
            = delegate(int value){ return counter.IsCountGreaterThanValue(value); } ;
        return greaterthanMethodFromParameterUsingAnonymousMethod(30);
    }

}