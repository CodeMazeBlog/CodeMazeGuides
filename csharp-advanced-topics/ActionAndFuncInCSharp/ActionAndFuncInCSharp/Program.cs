// Action example
void Print(string name)
{
    Console.WriteLine(name);
}

Action<string> printAction = Print;

printAction("John");

printAction.Invoke("John");

void PrintSum(int x, int y) { Console.WriteLine(x + y); }

Action<int, int> printSumAction = PrintSum;

printSumAction.Invoke(2, 3);

// Func example
bool IsNumberEven(int number) { return number % 2 == 0; }

Func<int, bool> isEvenFunc = IsNumberEven;

Console.WriteLine(isEvenFunc(10));

// Func lambda
Func<int, int> squareFunc = x => x * x;

int squareResult = squareFunc(5);

Console.WriteLine(squareResult);

// Action lambda
Action<string> printMessageAction = message => Console.WriteLine(message);

printMessageAction("Hello, world!");
