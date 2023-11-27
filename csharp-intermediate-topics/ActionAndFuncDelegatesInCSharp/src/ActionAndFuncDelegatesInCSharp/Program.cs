// Action delegate
Action<string> helloAction = SayHello;
Action<string> goodbyeAction = SayGoodbye;
InteractAction(helloAction, "John");    // Message: Hello John
InteractAction(goodbyeAction, "John");  // Message: Goodbye John

static void InteractAction(Action<string> action, string message)
{
    action(message);
}

static void SayHello(string name)
{
    string message = $"Hello {name}";
    Console.WriteLine($"Message: {message}");
}

static void SayGoodbye(string name)
{
    string message = $"Goodbye {name}";
    Console.WriteLine($"Message: {message}");
}

// Func delegate
Func<int, int, int> addFunc = AddNumbers;
Func<int, int, int> subtractFunc = SubtractNumbers;
int addResult = CalculateFunc(addFunc, 7, 5);           // Result: 12
int subtractResult = CalculateFunc(subtractFunc, 7, 5); // Result: 2
Console.WriteLine($"Add result: {addResult}");
Console.WriteLine($"Subtract result: {subtractResult}");

static TResult CalculateFunc<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 arg1, T2 arg2)
{
    return func(arg1, arg2);
}

static int AddNumbers(int a, int b)
{
    return a + b;
}

static int SubtractNumbers(int a, int b)
{
    return a - b;
}
