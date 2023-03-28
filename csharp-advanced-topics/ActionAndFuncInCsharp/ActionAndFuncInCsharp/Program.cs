
// Func

Func<int, int, int> SunstractionOfNumbers = DifferenceBetweenTwoNumbers;

int rest = SunstractionOfNumbers(9, 4);

Console.WriteLine("The rest of substracting 4 from 9 is: " + rest);

//Func with lambda expression

Func<int, int, int> SubstractionResult = (a, b) => a - b;

Console.WriteLine("The rest of substracting 6 from 8 is: " + SubstractionResult(8, 6));

// Func with Linq

Func<int, bool> IsDecimalNumber = num => num > 10;

int[] numbers = { 1, 4, 11, 2, 15, 7 };

IEnumerable<int> decimalNumber = numbers.Where(IsDecimalNumber);

foreach (var number in decimalNumber)
{
    Console.WriteLine($"{number} is a decimal number");
}

// Same Func example without Linq
foreach (var number in numbers)
{
    if (number > 10)
    {
        Console.WriteLine($"Getting the decimal number {number} without Func");
    }
}


// Action

Action action1 = MyVoidMethod;
action1();

Action action2 = () => Console.WriteLine("This is my first Action");

Action<string> action3 = MyVoidMethodWithArgument;
action3("Code-Maze");

// Methods

static int DifferenceBetweenTwoNumbers(int a, int b)
{
    return a - b;
}

static void MyVoidMethodWithArgument(string str)
{
    Console.WriteLine($"This is an Action with {str} as string parameter");
}

static void MyVoidMethod()
{
    Console.WriteLine("This is my first Action");
}
