Action<string> printMessage = (message) =>
{
    Console.WriteLine(message);
};

printMessage("Hello, Action delegate!");

Func<int, int> square = (x) =>
{
    return x * x;
};

int result = square(5);
Console.WriteLine("Square of 5 is: " + result);
