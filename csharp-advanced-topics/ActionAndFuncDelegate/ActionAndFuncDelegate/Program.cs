using System;

namespace ActionAndFuncDelegates
{
    class Program
    {
        const char delimeter = ' ';
        const string format = "dddd, MMMM dd yyyy";
        static void Main(string[] args)
        {
            // Action Delegate implementation with 2 parameters
            Action<string, string> printTwoStrings = PrintText;
            printTwoStrings("Hello", "World!");

            // Action Delegate implementation with 3 parameters
            Action<string, string, string> printThreeStrings = PrintText;
            printThreeStrings("All", "The", "Best!");

            // Func Delegate implementation
            Func<int, int, int, string, string> getDateString = CrateDateString;
            Console.WriteLine(string.Concat("Last date of year is " ,getDateString(2021, 12, 31, format)));

        }

        static void PrintText(string first, string second)
        {
            Console.WriteLine(string.Concat(first, delimeter, second));
        }
        static void PrintText(string first, string second, string third)
        {
            Console.WriteLine(string.Concat(first, delimeter, second, delimeter, third));
        }

        static string CrateDateString(int day, int second, int third, string format)
        {
            return new DateTime(day, second, third).ToString(format);
        }

    }
}
