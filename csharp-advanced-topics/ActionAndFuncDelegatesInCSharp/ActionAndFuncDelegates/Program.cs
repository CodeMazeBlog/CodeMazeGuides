namespace ActionAndFuncDelegates
{
internal class Program
{
    static void Main(string[] args)
    {
        //Action delegates examples
        var info = "info";
        var error = "error";

        ActionDelegates.LogInformation(info);
        ActionDelegates.LogError(error);


        Action<string> logInfo = (infoDetail) => ActionDelegates.LogInformation(info);
        Action<string> logError = (errorDetail) => ActionDelegates.LogError(error);

        // Func delegate examples
        Func<int, int, int> operation1 = (x, y) => FuncDelegates.Add(x, y);
        Func<int, int, int> operation2 = (x, y) => FuncDelegates.Subtract(x, y);
        Func<int, int, int> operation3 = (x, y) => FuncDelegates.Multiply(x, y);

        Console.WriteLine($"The results of these operations are: {operation1(4, 5)}, {operation2(4, 5)}, {operation3(4, 5)}");

    }
}
}