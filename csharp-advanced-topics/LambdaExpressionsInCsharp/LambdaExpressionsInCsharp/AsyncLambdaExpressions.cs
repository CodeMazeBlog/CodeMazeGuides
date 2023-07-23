namespace LambdaExpressionsInCsharp;
public class AsyncLambdaExpressions
{
    public static async Task AsyncExpressionLambda()
    {
        var lamda = async () => await Task.Delay(1000);
        await lamda();
        Console.WriteLine("Completed async task");
    }

    public static async Task AsyncStatementLambda()
    {
        var lamdba = async () =>
        {
            await Task.Delay(1000);
            Console.WriteLine("Completed async task");
        };
        await lamdba();
    }
}
