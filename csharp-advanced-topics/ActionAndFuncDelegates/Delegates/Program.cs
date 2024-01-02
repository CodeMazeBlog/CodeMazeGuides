using Microsoft.VisualBasic;
using System.Reflection;

namespace Delegates
{
    public class Program
    {
        delegate T ModifyData<T>(T str);
        static string upperStr = string.Empty;

        static string Reverse(string myString)
        {
            var characters = myString.ToCharArray();
            Array.Reverse(characters);
            return new string(characters);
        }

        static string LowerString(string myString)
        {
            return myString.ToLowerInvariant();
        }

        static void UpperString(string myString)
        {
            upperStr = myString.ToUpperInvariant();
        }

        static bool isUpperString(string str)
        {
            return str.Equals(str.ToUpperInvariant());
        }

        static void Main(string[] args)
        {

            ModifyData<string> modifyString = Reverse;
            Console.WriteLine("Welcome to Code Maze!");
            Console.WriteLine(modifyString("Welcome to Code Maze!"));

            Func<string, string> stringFunction = Reverse;
            Console.WriteLine("Hello world!");
            Console.WriteLine(stringFunction("Hello world!"));

            Action<string> modifyCase = UpperString;
            Console.WriteLine("Hello world using delegates!");
            modifyCase("Hello world using delegates!");
            Console.WriteLine(upperStr);

            Predicate<string> checkString = isUpperString;
            Console.WriteLine("THIS IS A CAPITALIZED STRING.");
            var result = checkString("THIS IS A CAPITALIZED STRING.");
            Console.WriteLine(result);

            modifyString += LowerString;
            var delegates = modifyString.GetInvocationList();
            Console.WriteLine(modifyString("A TEST WITH A MULTICAST DELEGATE."));
            foreach(var del in delegates)
            {
                Console.WriteLine(del.Method.Name);
            }
        }
    }
}
