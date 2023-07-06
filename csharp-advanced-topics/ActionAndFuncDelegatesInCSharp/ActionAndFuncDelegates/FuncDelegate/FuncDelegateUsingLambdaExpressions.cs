   public partial class FuncDelegateInCSharp
{
   public bool ExecuteWithoutParameterUsingLambdaExpressions()
    {
        Func<bool> checkEvenNumberMethodUsingLambdaExpression
                = () => counter.IsCountEven() ;

         return checkEvenNumberMethodUsingLambdaExpression();
    }

    public bool ExecuteWithParameterUsingLambdaExpressions()
    {
      Func<int, bool> greaterthanMethodFromParameterUsingLambdaExpression 
            = value => counter.IsCountGreaterThanValue(value) ;

         return greaterthanMethodFromParameterUsingLambdaExpression(30);
    }
}
