using System.Xml.Linq;
using System.Linq;

namespace ActionAndFuncDelegates
{
    internal class Program
    {
        private static readonly List<string> _names = new() {
            "Paul",
            "Aaron",
            "Amy",
            "World"
        };
        
        delegate void Print2(string name);

        static void Main(string[] args)
        {
            Action<string> actionMsg = GoodbyeMessage;
            Func<bool, string, string> funcMsg = IsThisGoodBye;
            
            Func<bool> anonymousFunc = delegate() { return true; };
            Func<bool> lambdaFunc = () => { return true; };

            Console.WriteLine($"{CountOfNamesContaining("A", true)} names start with A");
            Console.WriteLine($"{CountOfNamesContaining("d", false)} names end with D");

            actionMsg("Paul");

            // Display the contents of the list using the Print method.
            _names.ForEach(Print);

            AnonymousPrint();
            Console.WriteLine(funcMsg(true, "Paul"));
            Console.WriteLine(funcMsg(false, "Aaron"));
        }

        static void Print(string s)
        {
            Console.WriteLine($"Hello {s}");
        }

        static void AnonymousPrint()
        {
            // Anonymous method to display the contents of the list.
            _names.ForEach(delegate (string name)
            {
                Console.WriteLine(name);
            });
        }
        public static void GoodbyeMessage(string name) => Console.WriteLine($"Goodbye {name}");

        public static string IsThisGoodBye(bool goodbye, string name)
        {
            if (goodbye)
                return $"Goodbye, {name}";
            else
                return $"Hello, {name}";
        }

        public static int CountOfNamesContaining(string searchString, bool searchFromBeginning)
        {
            Func<string, string, bool> compare;

            if (searchFromBeginning)
                compare = NameStartsWith;
            else
                compare = NameEndsWith;

            return _names.Count(n => compare(n, searchString));
        }

        private static bool NameStartsWith(string name, string beginsWith)
        {
            return (name.StartsWith(beginsWith));
        }
        private static bool NameEndsWith(string name, string endsWith)
        {
            return (name.EndsWith(endsWith));
        }
    }
}