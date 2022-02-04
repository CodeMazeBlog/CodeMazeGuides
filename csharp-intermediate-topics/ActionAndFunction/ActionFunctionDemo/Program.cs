using System;

namespace ActionFunctionDemo
{
    public class Program
    {
        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static void DisplayName(string nameOfPerson)
        {
            Console.WriteLine(nameOfPerson);
        }

        static void Main(string[] args)
        {
            Func<int, int, int> multiplyDelegate = Multiply;
            Console.WriteLine(multiplyDelegate(2, 5));

            Action<string> writeDelegate = DisplayName;
            writeDelegate("Rebecca Jay");
        }
    }
}