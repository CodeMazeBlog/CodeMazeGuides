Action<string> printAction = PrintMessage;

printAction("Hello code maze, this is an action delegate!");

static void PrintMessage(string message)
{
    Console.WriteLine(message);
}

Func<int, int> squareFunc = Square;

int result = squareFunc(7);
Console.WriteLine($"Square of 7 is {result}");

static int Square(int number)
{
    return number * number;
}