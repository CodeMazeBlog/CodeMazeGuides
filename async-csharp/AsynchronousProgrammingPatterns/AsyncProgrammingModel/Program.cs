using System;

namespace AsynchronousProgrammingModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AsyncProgrammingModelHelper.FetchAndPrintUser(100);

            Console.ReadKey();
        }
    }
}
