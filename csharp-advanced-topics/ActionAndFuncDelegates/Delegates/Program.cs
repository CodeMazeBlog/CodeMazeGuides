using Microsoft.VisualBasic;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Delegates
{
    public delegate T ModifyData<T>(T str);

    public class Program
    {
        public static string upperStr = string.Empty;

        public static string Reverse(string myString)
        {
            var characters = myString.ToCharArray();
            Array.Reverse(characters);
            return new string(characters);
        }

        public static string LowerString(string myString)
        {
            return myString.ToLowerInvariant();
        }

        public static void UpperString(string myString)
        {
            upperStr = myString.ToUpperInvariant();
        }

        public static bool IsUpperString(string str)
        {
            return str.Equals(str.ToUpperInvariant());
        }

        public static string ReverseUsingDelegate(ModifyData<string> modifyData, string str)
        {            
            Console.WriteLine(nameof(ReverseUsingDelegate));
            
            return modifyData(str);
        }

        public static string UseMulticastDelegate(ModifyData<string> modifyString, string str)
        {
            Console.WriteLine(nameof(UseMulticastDelegate));
            return modifyString(str);
        }

        public static string GetInvocationListFromMulticastDelegate(ModifyData<string> modifyString)
        {
            var delegates = modifyString.GetInvocationList();
            Console.WriteLine($"Number of methods referenced by the multicast delegate: {delegates.Length}");
            var stringReturn = string.Empty;

            foreach (var del in delegates)
            {
                stringReturn += del.Method.Name + " ";
            }

            return stringReturn.TrimEnd();
        }

        public static string UseMulticastFunc(Func<string, string> f, string str)
        {
            Console.WriteLine(nameof(UseMulticastFunc));
            return f(str);
        }

        public static string UseAction(Action<string> modifyAction, string str)
        {
            Console.WriteLine(nameof(UseAction));
            modifyAction(str);

            return upperStr;
        }

        public static bool UsePredicate(Predicate<string> check, string str)
        {
            Console.WriteLine(nameof(UsePredicate));
            return check(str);
        }

        static void Main(string[] args)
        {
            var str = "Welcome to Code Maze!";

            // String reverse
            Console.WriteLine(ReverseUsingDelegate(Reverse, str));

            // String reverse and string lower case
            ModifyData<string> modifyString = Reverse;
            modifyString += LowerString;
            Console.WriteLine(UseMulticastDelegate(modifyString, str));

            // List of methods referenced by the multicast delegate 
            Console.WriteLine(GetInvocationListFromMulticastDelegate(modifyString));

            // string lower case and reverse string using Func
            Console.WriteLine(UseMulticastFunc((Func<string, string>)LowerString + (Func<string, string>)Reverse, str));

            // string upper case using Action
            Console.WriteLine(UseAction(UpperString, str));

            // check if string is upper case
            Console.WriteLine(UsePredicate(IsUpperString, str.ToUpper()));
        }
    }
}
