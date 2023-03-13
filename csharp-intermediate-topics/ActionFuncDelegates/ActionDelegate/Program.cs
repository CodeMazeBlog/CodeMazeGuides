using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ActionDelegate
{
    internal class Program
    {
        static void PrintAWord(string word)
        {
            Console.WriteLine(word);
        }

        static void Main(string[] args)
        {
            List<string> words = new List<string> { "apple", "banana", "cherry", "date" };

            // create an Action delegate and assign it a method
            Action<string> actionPrintWord = PrintAWord;

            // calling the Action
            words.ForEach(w => actionPrintWord(w));

            // alternate-1: using the anonymous method
            words.ForEach(delegate (string word) { Console.WriteLine(word); });

            // alternate-2: using the lambda expression
            words.ForEach(w => Console.WriteLine(w));
        }
    }
}
