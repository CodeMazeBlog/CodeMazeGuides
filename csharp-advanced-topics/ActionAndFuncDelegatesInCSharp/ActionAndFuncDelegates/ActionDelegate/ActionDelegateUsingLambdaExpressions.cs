public partial  class ActionDelegateInCSharp
{
    
     public void ExecuteWithoutParameterUsingLambdaExpressions()
    {
        Action showMethodUsingLambdaExpression = () => nameDisplay.DisplayValue();
        showMethodUsingLambdaExpression();
    }

    public void ExecuteWithParameterUsingLambdaExpressions()
    {
        Action<string> showMethodWithParameterUsingLambdaExpression = name => nameDisplay.DisplayValue(name);
        showMethodWithParameterUsingLambdaExpression("Code Maze from Parameters using Lambda Expressions");
    }
}