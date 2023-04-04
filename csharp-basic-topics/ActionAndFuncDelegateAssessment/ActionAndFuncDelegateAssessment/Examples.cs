namespace ActionAndFuncDelegateAssessment;

public static class Examples
{
    public static int FuncDelegateExample(IEnumerable<int> numbers) => numbers.Sum(n => n);

    public static void ActionDelegateExample(List<int> numbers)
    {
        Action<int> printToConsole = number => Console.WriteLine(number);
        numbers.ForEach(printToConsole);
    }

    public static async Task<double> MultithreadExample()
    {
        var calculateSumFunc = new Func<double>(CalculateSum);
        var resultTask = Task.Run(calculateSumFunc);
        var result = await resultTask;
        return result;
    }

    private static double CalculateSum()
    {
        double sum = 0;
        for (var i = 1; i <= 100000000; i++) sum += i;
        return sum;
    }
}