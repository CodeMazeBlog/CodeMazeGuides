namespace ActionAndFuncDelegatesInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegateExample.SendMailDelegate();
            
            ActionExamples.ActionWithAnonymouseMethod();
            ActionExamples.ActionWithExpressionLambda();
            ActionExamples.ActionWithStatementLambda();
            
            FuncExamples.FuncWithAnonymouseMethod();
            FuncExamples.FuncWithExpressionLambda();
            FuncExamples.FuncWithStatementLambda();
        }
    }
}