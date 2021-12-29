using System;

namespace Delegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            Action<string> logToConsole = (msg) => Console.WriteLine(msg);
            Action<string> logToFile = (msg) => File.AppendAllText("log.txt", msg); 

            Func<int, bool> oddNumber = (num) => num % 2 == 1;
            Func<int, bool> evenNumber = (num) => num % 2 == 0;

            //logs odd numbers to a file.
            GenerateData(oddNumber, logToFile);

            //logs even numbers to console.
            GenerateData(evenNumber, logToConsole);
        }

        public static void GenerateData(Func<int, bool> predicate, Action<string> logger)
        {
            var numbers = Enumerable.Range(1, 100)
                            .Where(predicate)
                            .ToList();
            
            logger(String.Join(',', numbers));
        }
    }
    
}
