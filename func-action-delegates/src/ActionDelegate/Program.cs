using System;
namespace ActionDelegate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action<string, string> actionDelegate = Print;
            actionDelegate("Code", "Maze");
            Console.ReadLine();
        }
        public static void Print(string firstName, string lastName)
        {
            string fullName = firstName + lastName;
            Console.WriteLine($"{fullName}");
        }
    }
}
