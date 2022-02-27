using System;
namespace FuncDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, string> funcDelegate = Append;
            string fullName = funcDelegate("Code", "Maze");
            Console.WriteLine(fullName);
            Console.ReadLine();
        }
        static string Append(string firstName, string lastName)
        {
            return firstName + lastName;
        }
    }
}
