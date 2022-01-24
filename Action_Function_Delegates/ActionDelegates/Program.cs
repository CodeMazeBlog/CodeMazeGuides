using System;

namespace ActionDelegates
{
    public static class Program
    {
        // Use Direct Definition
        public delegate void Action_Delegate(int value);
        public static void Print_Action_Delegate(int number)
        {
            Console.WriteLine(number);
        }

        // Use Action Method

        public static void Main(string[] args)
        {
            // Use Direct Definition
            Action_Delegate action_Delegate = Print_Action_Delegate;
            action_Delegate(10);

            // Use Action Method
            Action<int, int> action_Delegates = delegate (int i, int j)
            {
                Console.WriteLine(Convert.ToString(i + j));
            };
            action_Delegates(10, 20);

            // Assign an anonymous method to the action delegate
            Action<string> printActionDel = delegate (string name)
            {
                Console.WriteLine($"Hello {name}");
            };
            printActionDel("Vahidal");

            // Lambda expression
            Action<string> name = UserName => Console.WriteLine(UserName);
            name("Hello Vahidal");
        }
    }
}
