using System;
namespace FuncDelegate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Func<string, string, string> funcDelegate = Append;
            string fullName = funcDelegate("Code", "Maze");
            Console.WriteLine(fullName);
            Console.ReadLine();
        }
        public static string Append(string firstName, string lastName)
        {
            return firstName + lastName;
        }
    }
}
