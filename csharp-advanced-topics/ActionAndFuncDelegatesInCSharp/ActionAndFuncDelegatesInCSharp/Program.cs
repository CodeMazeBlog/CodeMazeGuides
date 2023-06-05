using System;

namespace ActionAndFuncDelegatesInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var example = new Example();

            example.ActionDemo();

            example.FuncDemo();

            Console.ReadLine();
        }
    }
}
