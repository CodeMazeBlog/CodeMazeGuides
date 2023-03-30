namespace ActionAndFuncDelegateAssessment;

public static class Examples
{
    public static int FuncDelegateExample(IEnumerable<int> numbers) => numbers.Sum();

    public static void ActionDelegateExample(IEnumerable<int> numbers)
    {
        foreach (var number in numbers) Console.WriteLine(number);
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