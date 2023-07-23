using System;

namespace BreakAndContinueStatementsInCsharp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("We're looping from 1 to 10!");

            Console.WriteLine("Here's a loop that breaks just before printing 5");
            BreakLoopAt5();

            Console.WriteLine("Here's a loop that continues for non-multiples of 3");
            ContinueLoopForNonMultipesOf3();
        }

        public static void BreakLoopAt5()
        {
            for (var i = 1; i <= 10; i++)
            {
                if (i == 5)
                {
                    break;
                }
                Console.WriteLine($"Our current number is: {i}");
            }
        }

        public static void ContinueLoopForNonMultipesOf3()
        {
            var i = 0;
            while (i < 10)
            {
                i++;
                if (i % 3 != 0)
                {
                    continue;
                }
                Console.WriteLine($"{i} is a multiple of 3");
            }
        }
    }
}
