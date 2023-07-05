   public partial class FuncDelegateInCSharp
{
   public void ExecuteWithoutParameterUsingLambdaExpressions()
    {
        Func<bool> validationMethodUsingLambdaExpression 
                =  delegate(){return nameValidator.IsNameValid();} ; 
        Console.WriteLine(validationMethodUsingLambdaExpression());
    }

    public void ExecuteWithParameterUsingLambdaExpressions()
    {
      Func<string, bool> validationFromParameterMethodUsingLambdaExpression 
            = delegate(string name){return nameValidator.IsNameValid(name);} ;
        Console.WriteLine(validationFromParameterMethodUsingLambdaExpression("Code Maze from Parameter should return false"));
    }
}
