// See https://aka.ms/new-console-template for more information



Console.WriteLine(ExecArithmeticOperation(Sum, 2, 3));



int ExecArithmeticOperation(Func<int, int, int> operation, int operand1, int operand2)
{
    return operation(operand1, operand2);
}

int Sum(int a, int b)
{
    return a + b;
}