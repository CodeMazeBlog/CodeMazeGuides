using System;

namespace ActionAndFuncDelegates
{
    internal class ActionWithNoParameter
    {
        static void Main(string[] args)
        {
            // Action delegate without parameters
            Action printInformation = () => 
            {
                Console.WriteLine("It prints without parameter");
            };

            printInformation();

            Console.ReadLine();
        }
    }
}
