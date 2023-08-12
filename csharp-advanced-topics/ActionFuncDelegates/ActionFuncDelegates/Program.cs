using ActionFuncDelegates;

internal class Program
{
    private static void Main(string[] args)
    {
        DelegatesDemo.CalculateAndPrint(6, 3, MathOperation.Add);
        DelegatesDemo.CalculateAndPrint(6, 3, MathOperation.Subtract);
        DelegatesDemo.CalculateAndPrint(6, 3, MathOperation.Multiply);
        DelegatesDemo.CalculateAndPrint(6, 3, MathOperation.Divide);

        FuncActionDemo.CalculateAndPrint(6, 3, MathOperation.Add);
        FuncActionDemo.CalculateAndPrint(6, 3, MathOperation.Subtract);
        FuncActionDemo.CalculateAndPrint(6, 3, MathOperation.Multiply);
        FuncActionDemo.CalculateAndPrint(6, 3, MathOperation.Divide);
    }
}