using System;
using System.ComponentModel;

namespace EvaluationDemoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, string> func = AppendText; //Func delegate declaration
            string AppendedName = func("Code", "Maze"); //invoking the delegate
            Console.WriteLine(AppendedName);
            Console.ReadLine();

            Action<string, string> writeDelegate = AppendPrint; //Action delegate declaration
            writeDelegate("Evaluation", "Article"); //invoking the delegate

        }
        static string AppendText(string firstText, string lastText)
        {
          return firstText + " " + lastText;
        }

        static void AppendPrint(string first, string last)
        {
            string fullText = first + " " + last;
            Console.WriteLine($"{fullText}");
        }
    }
}