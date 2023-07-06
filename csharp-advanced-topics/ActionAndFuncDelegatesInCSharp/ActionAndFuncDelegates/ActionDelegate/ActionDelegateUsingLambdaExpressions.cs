public partial  class ActionDelegateInCSharp
{
    
     public void ExecuteWithoutParameterUsingLambdaExpressions()
    {
        Action incrementMethodUsingLambdaExpression = () => counter.Increment();
        incrementMethodUsingLambdaExpression();
    }

    public void ExecuteWithParameterUsingLambdaExpressions()
    {
        Action<int> incrementMethodWithParameterUsingLambdaExpression = value => counter.IncrementBy(value);
        incrementMethodWithParameterUsingLambdaExpression(20);
    }
}