using static ActionsAndFuncsInCSharp.Printing;

namespace ActionsAndFuncsInCSharp
{
    public static class Actions
    {
        public static void RunAllExamples()
        {
            RunExample1();
            RunExample2();
            RunExample3();
            RunExample4();
            RunExample5();
            RunExample6();
        }

        public static bool RunExample1()
        {
            // Example 1: Basic Action implementation.
            Action printSomething1 = PrintInfo;
            Console.Write("Actions Example 1: ");
            printSomething1();

            return true;
        }

        public static bool RunExample2()
        {
            // Example 2: Action<T> with parameter of type string.
            Action<string> printSomething2 = PrintInfo;
            Console.Write("Actions Example 2: ");
            printSomething2("Hello world!");

            return true;
        }

        public static bool RunExample3()
        {
            // Example 3: Basic Action instantiated.
            Action printSomething3 = new Action(PrintInfo);
            Console.Write("Actions Example 3: ");
            printSomething3();

            return true;
        }

        public static bool RunExample4()
        {
            // Example 4: Action<T> defined anonymously with string type parameter.
            Action<string> printSomething4
                = delegate (string caption)
                {
                    Console.WriteLine(caption);
                };

            Console.Write("Actions Example 4: ");
            printSomething4("Hello world!");

            return true;
        }

        public static bool RunExample5()
        {
            // Example 5: Action<T> defined using lambda expression with string type parameter.
            Action<string> printSomething
                = caption => Console.WriteLine(caption);

            Console.Write("Actions Example 5: ");
            printSomething("Hello world!");

            return true;
        }

        public static bool RunExample6()
        {
            // Example 6: Action<T> with multiple paramters of type integer. (Lambda example 2)
            Action<int, int> multiply
                = (x, y) => Console.WriteLine(x * y);

            Console.Write("Actions Example 6: ");
            multiply(4, 4);

            return true;
        }
    }
}