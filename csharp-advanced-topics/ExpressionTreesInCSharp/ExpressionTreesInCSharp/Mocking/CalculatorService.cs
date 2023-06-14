namespace ExpressionTreesInCSharp.Mocking;
public class CalculatorService
{
    private readonly ICalculator _calculator;

    public CalculatorService(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public int AddTwoNumbers(int number1, int number2)
    {
        return _calculator.Add(number1, number2);
    }
}
