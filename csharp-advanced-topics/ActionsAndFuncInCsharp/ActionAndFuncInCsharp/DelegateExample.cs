namespace ActionAndFuncInCsharpConsole;

public class DelegateExample
{
    public delegate int Calculate(int a, int b);

    public delegate void LoggerInfo(string message); 

    public int Sum(int a, int b)
    {
        return a + b;
    }

    public int Difference(int a, int b)
    {
        return a - b;
    }

    public void PerformCalculate()
    {
        Calculate add = Sum;
        Calculate substract = Difference;

        int result = add(1, 2) + substract(2, 1); 
        Console.WriteLine(result);
    }

    public void PerformCalculate(Calculate cal)
    {
        var result = cal(2,2) + 1;
        Console.WriteLine(result);
    }
    
    public void PerformCalculate(Calculate cal, LoggerInfo loggerInfo)
    {
        var result = cal(2,2) + 1;
        loggerInfo("result:" + result);
    }
}