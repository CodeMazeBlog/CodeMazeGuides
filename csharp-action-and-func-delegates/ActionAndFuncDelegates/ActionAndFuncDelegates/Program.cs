// We defined an Action delegate that points to the PrintMessage method.
Action<string> printAction = PrintMessage;

// Invoke the method via delegate and print the result to the console.
printAction("Hello code maze, this is an action delegate!");

static void PrintMessage(string message)
{
    Console.WriteLine(message);
}



// We defined a Func director that takes an int and returns its square.
Func<int, int> squareFunc = Square;

// Invoke the method via delegate and print the result to the console.
int result = squareFunc(7);
Console.WriteLine($"Square of 7 is {result}");

static int Square(int number)
{
    return number * number;
}