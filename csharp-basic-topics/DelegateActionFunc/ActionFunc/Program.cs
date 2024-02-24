// See https://aka.ms/new-console-template for more information


static int SumFunc(int a, int b) => a + b;

var result = SumFunc(3, 4);

Action<int, int> ActionCalculatorAddition = (a, b) =>
{
    Console.WriteLine($"Addition result: {a + b}");
};

Action<int, int> ActionCalculatorSubtraction = (a, b) =>
{
    Console.WriteLine($"Subtraction result: {a - b}");
};

Action<int, int> ActionCalculatorMultiplication = (a, b) =>
{
    Console.WriteLine($"Multiplication result: {a * b}");
};

Action<int, int> ActionCalculatorDivision = (a, b) =>
{ 
    Console.WriteLine($"Division result: {a / b}");
};

ActionCalculatorAddition(9, 3);


ActionCalculatorSubtraction(9, 3);


ActionCalculatorDivision(9, 3);


ActionCalculatorMultiplication(9, 3);


ActionCalculatorDivision(9, 3);

Console.ReadLine();