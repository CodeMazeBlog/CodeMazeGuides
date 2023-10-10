namespace ActionAndFuncDelegates
{
    public class DelegateFunctionality
    {
        public static string IsThisGoodBye(bool goodbye, string name)
        {
            if (goodbye)
                return $"Goodbye, {name}";
            else
                return $"Hello, {name}";
        }

        public static void GoodbyeMessage(string name) => Console.WriteLine($"Goodbye {name}");

        public static int CountOfListItemsContaining(List<string> list, string searchString, bool searchFromBeginning)
        {
            // use a lambda to filter names from the list
            Func<string, string, bool> compare;

            if (searchFromBeginning)
                compare = NameStartsWith;
            else
                compare = NameEndsWith;

            return list.Count(n => compare(n, searchString));
        }

        public static bool NameStartsWith(string name, string beginsWith)
        {
            return (name.StartsWith(beginsWith));
        }

        public static bool NameEndsWith(string name, string endsWith)
        {
            return (name.EndsWith(endsWith));
        }

        public static void AnonymousPrint(List<string> list)
        {
            // Anonymous method to display the contents of the list.
            list.ForEach(delegate (string name)
            {
                Console.WriteLine(name);
            });
        }

        public static void Print(string s)
        {
            Console.WriteLine($"Hello {s}");
        }

        public static bool AnonymousLessThanTen(int number) { return (number < 10); }

        public static readonly Func<int, bool> LambdaLessThanTen = (i) => { return i < 10; };
    }
}
