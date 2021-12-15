class CodeMaze
{
    void exampleOne()
    {
        Func<int, int, int> Calculate = Add; // our func that will calculate the result
        Action<int> Print = PrintWithAsterisk; // our action that will print the result
        int result = Calculate(3, 4); // calculating the result
        Print(result); // printing it
    }

    int Add(int a, int b) // takes two integers and returns the sum
    {
        return a + b;
    }

    void PrintWithAsterisk(int n) // takes an integer and prints it in a custom format
    {
        Console.WriteLine($"*** {n} ***");
    }

    void exampleTwo()
    {
        Func<int, int, int> calculate = (a, b) => a - b;
        Action<int> print = n => Console.WriteLine($"The result is: {n}");
        int result = calculate(8, 2);
        print(result);
    }

    void exampleThree()
    {
        Func<int, int, int> calculate = delegate(int a, int b) { return a * b; };
        Action<int> print = delegate(int n) { Console.WriteLine($"The result is: {n}"); };
        int result = calculate(2, 2);
        print(result);
    }

    void exampleFour()
    {
        Func<int, int, int> calculate = delegate(int a, int b) { return a * b; };
        Action<int> print = delegate(int n) { Console.WriteLine($"The result is: {n}"); };
        int result = calculate(2, 2);
        print += n => Console.WriteLine("*****************");
        print(result);
    }
}