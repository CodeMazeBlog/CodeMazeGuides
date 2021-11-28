using System;

namespace DelegatesInCsharp
{
    class Program
    {
        //Declaration
        public delegate void FirstOperationDelegate(int a, int b);

        static void Main(string[] args)
        {
            //Delegate
            //Instantiation
            FirstOperationDelegate addingOperation = new FirstOperationDelegate(Adding);
            //Invocation
            addingOperation(2, 3);

            //Action Declaration
            Action<string, int> action = new Action<string, int>(DisplayNameAndAge);
            //Invocation
            action("Peter", 20);

            //Func Declaration
            Func<int, int, int> addingFuncOperation = AddingFunc;
            Console.WriteLine("Func execution");
            //Invocation
            Console.WriteLine($"Result of addition is :{addingFuncOperation(2, 3)}");
            Console.ReadLine();
        }

        public static void Adding(int a, int b)
        {
            Console.WriteLine("Delegate execution");
            Console.WriteLine($"Result of addition is :{a + b}");
            Console.ReadLine();
        }

        static void DisplayNameAndAge(string username, int age)
        {
            Console.WriteLine("Action execution");
            Console.WriteLine($"The username is {username} and the age is {age}.");
            Console.ReadLine();
        }

        public static int AddingFunc(int a, int b)
        {
            return a + b;
        }
    }
}
