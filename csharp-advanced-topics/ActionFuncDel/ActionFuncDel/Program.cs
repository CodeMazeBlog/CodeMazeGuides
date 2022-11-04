using System;

namespace ActionFuncDel
{
    public class ActionFuncMethods
    {
        //Methods that accept parameters but doesn't return value

        public static void DisplayMsg()
        {
            Console.WriteLine("Welcome to Action and Func delegates");
        }
        public static void DisplayNumbers(int num, int total)
        {
            for (int i = num; i <= total; i++)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine();
        }
        public static void Display(string msg)
        {
            Console.WriteLine(msg);
        }

        //Methods that accept parameters and returns a value

        public static int Add(int i, int j)
        {
            return i + j;
        }

        public static string ShowAddition(int i, int j)
        {
            return string.Format("Sum of {0} and {1} is {2}", i, j, i + j);
        }

        public static string FullName(string firstname, string lastname)
        {
            return string.Format("Full Name is {0} {1}", firstname, lastname);
        }
        public static int DisplayNum()
        {
            Random r = new Random();
            return r.Next();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Action displayMsg = new Action(ActionFuncMethods.DisplayMsg);
            Action<string> display = new Action<string>(ActionFuncMethods.Display);
            Action<int, int> displayNumbers = new Action<int, int>(ActionFuncMethods.DisplayNumbers);

            Func<int, int, int> add = new Func<int, int, int>(ActionFuncMethods.Add);
            Func<int, int, string> showAddition = new Func<int, int, string>(ActionFuncMethods.ShowAddition);
            Func<string, string, string> fullName = new Func<string, string, string>(ActionFuncMethods.FullName);
            Func<int> rand = new Func<int>(ActionFuncMethods.DisplayNum);

            Console.WriteLine("\n***************** Action Delegates ***************\n");
            displayMsg();
            display("Hello");
            displayNumbers(1, 8);
            Console.WriteLine();
            Console.WriteLine("**************** Func Delegates *****************\n");

            int addVal = add(13, 25);
            string showVal = showAddition(55, 85);
            string strName = fullName("abc", "xyz");
            int randNums = rand();

            Console.WriteLine("Sum of two numbers: {0}", addVal);
            Console.WriteLine(showVal);
            Console.WriteLine(strName);
            Console.WriteLine("Random Numbers: {0}", randNums);

            Console.ReadLine();
        }
    }
}
