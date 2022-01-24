using System;

namespace ActionAndFuncInCSharp
{
    public class Program
    {
        public enum Operations {Add, Subtract}

        public delegate int Operation(int x, int y);

        private static int Add(int x, int y)
        {
            return x + y;
        }

        private static int Subtract(int x, int y)
        {
            return (x - y);
        }

        public static int SimpleDelegate(string userInput, int x, int y)
        {

            Operation chosenOperation; // we make use of the delegate we defined on line 9

            if (userInput == "Add")
            {
                chosenOperation = Add;
            }
            else
            {
                chosenOperation = Subtract;
            }

            var answer = chosenOperation(x, y);
            return answer;
        }

        public static int UsingFunc(string userInput, int x, int y)
        {

            Func<int,int,int> chosenOperation; // we can use Func instead of defining custom delegates

            if (userInput == "Add")
            {
                chosenOperation = Add;
            }
            else
            {
                chosenOperation = Subtract;
            }

            var answer = chosenOperation(x, y);

            return answer;
        }

        public static void UsingAction(string userInput, int x, int y)
        {
            int Sum(int x, int y) => x + y;

            Action<int, int> chosenOperation;

            if (userInput == "Print")
            {
                chosenOperation = (a,b) => Console.WriteLine(Sum(a, b));
            }
            else
            {
                chosenOperation = (a, b) => Console.WriteLine("Ignored");
            }

            chosenOperation(x, y);

        }

        static void Main(string[] args)
        {
            SimpleDelegate("Add", 2, 3);
            UsingFunc("Add", 2, 3);
            UsingAction("Print", 1, 2);
        }
    }
}





