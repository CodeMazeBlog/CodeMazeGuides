using System;
namespace ActionDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string, string> actionDelegate = Print;
            actionDelegate("Code", "Maze");
            Console.ReadLine();
        }
        static void Print(string firstName, string lastName)
        {
            string fullName = firstName + lastName;
            Console.WriteLine($"{fullName}");
        }
    }
}