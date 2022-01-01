using System;

namespace FuncAndActionDelegates
{
    public class Program
    {
        public delegate int AdditionDelegate(int num1, int num2);
        public static void Main(string[] args)
        {
            AdditionDelegate additionDelegate = AddNumbers;
            var sum = additionDelegate(10, 20);
            Console.WriteLine(sum);

            Func<int, int, int> additionFuncDel = AddNumbers;
            var sum1 = additionFuncDel(15, 25);
            Console.WriteLine(sum1);

            Func<int, string> checkEvenFuncDel = (num) => num % 2 == 0 ? "Even" : "Odd";
            var result = checkEvenFuncDel(30);
            Console.WriteLine(result);

            Action printActionDel = PrintMessage;
            printActionDel();

            Action<string, string> printNameActionDel = PrintFullName;
            printNameActionDel("Jane", "Doe");

            Action<int> tripleNumActionDel = (num) => Console.WriteLine(num * 3);
            tripleNumActionDel(6);
        }

        public static int AddNumbers(int num1, int nums2)
        {
            return num1 + nums2;
        }

        public static void PrintMessage()
        {
            Console.WriteLine("THIS IS SPARTA!!!");
        }

        public static void PrintFullName(string firstName, string lastName)
        {
            Console.WriteLine(firstName + " " + lastName);
        }
    }
}
