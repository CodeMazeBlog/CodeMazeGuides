namespace ActionAndFuncDelegates;

public class Calculator
{
    public int Sum(int num1, int num2)
    {
        var result = num1 + num2;
        return result;
    }

    public void Print()
    {
        System.Console.WriteLine("The answer is 200");
    }
    public void PrintResult(int result)
    {
        System.Console.WriteLine($"The result is {result}");
    }

    public int Result()
    {
        var result = Sum(5, 5);
        return result;
    }

    public int Exponent(int number)
    {
        return number * number;
    }

}