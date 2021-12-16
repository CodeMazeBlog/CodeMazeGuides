class CodeMaze
{
    void exampleOne()
    {
        Func<int, int, int> Calculate = Add;
        Action<int> Print = PrintWithAsterisk;
        int result = Calculate(3, 4);
        Print(result);
    }

    int Add(int a, int b)
    {
        return a + b;
    }

    void PrintWithAsterisk(int n)
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