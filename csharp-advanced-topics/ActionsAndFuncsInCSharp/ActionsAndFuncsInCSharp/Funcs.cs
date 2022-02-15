using static ActionsAndFuncsInCSharp.Printing;

namespace ActionsAndFuncsInCSharp
{
    public static class Funcs
    {
        public static void RunAllExamples()
        {
            RunExample1();
            RunExample2();
            RunExample3();
            RunExample4();
        }

        public static bool RunExample1()
        {
            // Example 1: Basic Func implementation.
            Func<string> printSomething1 = PrintInfo2;
            Console.Write("Funcs Example 1: ");
            Console.WriteLine(printSomething1());

            return true;
        }

        public static int RunExample2()
        {
            // Example 2: Func<T1,T2> that gets a multiple of two values passed as paramters.
            Func<int, int, int> multiplyValues1 = Multiply;
            Console.Write("Funcs Example 2: ");
            Console.WriteLine(multiplyValues1(2, 4));

            return multiplyValues1(2, 4);
        }

        public static int RunExample3()
        {
            // Example 3: Func<T1,T2> with two input parameters implemented in an anonymius function.
            Func<int, int, int> multiplyValues2
                = delegate (int x, int y)
                {
                    return x * y;
                };

            Console.Write("Funcs Example 3: ");
            Console.WriteLine(multiplyValues2(4, 4));

            return multiplyValues2(4, 4);
        }

        public static int RunExample4()
        {
            // Example 4: Func<T1,T2> with two input parameters implemented in a lambda expression.
            Func<int, int, int> multiplyValues = (x, y) => x * y;
            Console.Write("Funcs Example 4: ");
            Console.WriteLine(multiplyValues(6, 4));

            return multiplyValues(6, 4);
        }
    }
}