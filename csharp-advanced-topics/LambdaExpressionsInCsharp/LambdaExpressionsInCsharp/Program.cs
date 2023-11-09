namespace LambdaExpressionsInCsharp;

public class Program
{
    static async Task Main(string[] args)
    {
        LambdaExpressions.ExpressionLambdaWithNoReturnTypeAndNoParameters();
        LambdaExpressions.ExpressionLambdaWithNoReturnTypeAndWithParameters();
        LambdaExpressions.ExpressionLambdaWithReturnTypeAndWithNoParameters();
        LambdaExpressions.ExpressionLambdaWithReturnTypeAndWithParameters();
        LambdaExpressions.StatementLambdaWithNoReturnTypeAndNoParameters();
        LambdaExpressions.StatementLambdaWithNoReturnTypeAndWithParameters();
        LambdaExpressions.StatementLambdaWithReturnTypeAndWithNoParameters();
        LambdaExpressions.StatementLambdaWithReturnTypeAndWithParameters();
        LambdaExpressions.LambdaNaturalType();
        LambdaExpressions.LambdaWithExplicitReturnType();

        var lambdaExpressionInLinq = new LambdaExpressionsInLinq();
        lambdaExpressionInLinq.LinqFirst();
        lambdaExpressionInLinq.LinqOrderBy();
        lambdaExpressionInLinq.LinqSelect();

        await AsyncLambdaExpressions.AsyncExpressionLambda();
        await AsyncLambdaExpressions.AsyncStatementLambda();

        var lambdaExpressionsInEvents = new LambdaExpressionsInEvents();
        lambdaExpressionsInEvents.InvokeEvent();
    }
}
