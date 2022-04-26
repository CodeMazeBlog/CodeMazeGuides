using System;

namespace ActionAndFuncExample
{
    public class CountChars
    {
        public static void WriteToConsoleFunc(Func<string, int> countFunc, string myString)
        {
            int count = countFunc(myString);
            Console.WriteLine("The total count is: {0}", count);
        }

        public static int CountCharsFunc(string myString)
        {
            int count = myString.Length; return count;
        }

        public static int CountWordsFunc(string myString)
        {
            int count = myString.Split(' ').Length; return count;
        }

        static void Main(string[] args)
        {
            //instantiation
            Action<Func<string, int>, string> WriteToConsoleDel = WriteToConsoleFunc;
            Func<string, int> countDel = CountCharsFunc;
            string stringToCount = "This is My First Func Delegate";
            //invocation
            WriteToConsoleDel(countDel, stringToCount);
        }
    }
}

