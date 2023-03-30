namespace ActionAndFuncInCsharp;

public class Program
{
    static void Main(string[] args)
    {
        // Func delegates

        Func<int, int, int> SunstractionOfNumbers = DifferenceBetweenTwoNumbers;

        int rest = SunstractionOfNumbers(9, 4);

        Console.WriteLine("The rest of substracting 4 from 9 is: " + rest);

        // We are calling a function that implements a Func with lambda expression

        FuncMethodResult();

        // We are calling a function that implements Func with Linq

        ReturnDecimalNumbersWithlinq();

        // We are calling a function that returns the same result as the previous one but without using a Func

        ReturnDecimalNummbersWithoutFunc();

        // Action delagates

        Action action1 = MyVoidMethod;
        action1();

        // Action with Lambda

        Action action2 = ActionAndFuncWithLambda.action2;
        action2();

        Action<string> action3 = MyVoidMethodWithArgument;
        action3("Code-Maze");
    }


    // Methods

    public static int DifferenceBetweenTwoNumbers(int a, int b)
    {
        return a - b;
    }

    public static void MyVoidMethodWithArgument(string str)
    {
        Console.WriteLine($"This is an Action with {str} as string parameter");
    }

    public static void MyVoidMethod()
    {
        Console.WriteLine("This is my first Action");
    }

    public static int FuncMethodResult()
    {
        int a = 8;
        int b = 6;
        int result = ActionAndFuncWithLambda.SubstractionResult(a, b);
        Console.WriteLine($"The rest of substracting {b} from {a} is: "
            + result);
        return result;
    }

    public static void ReturnDecimalNumbersWithlinq()
    {

        foreach (var number in ActionAndFuncWithLambda.GetDecimalNumbers())
        {
            Console.WriteLine($"{number} is a decimal number");
        }
    }

    public static void ReturnDecimalNummbersWithoutFunc()
    {

        int[] numbers = { 1, 4, 11, 2, 15, 7 };

        foreach (var number in numbers)
        {
            if (number > 10)
            {
                Console.WriteLine($"Getting the decimal number {number} without Func");
            }
        }
    }
}



