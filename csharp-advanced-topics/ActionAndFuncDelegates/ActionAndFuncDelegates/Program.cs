namespace ActionAndFuncDelegates
{
    internal class Program
    {
        private static readonly List<string> _names = new() {
            "Dave",
            "Mike",
            "Anna",
            "Arnold"
        };
        
        static void Main(string[] args)
        {
            Action<string> actionMsg = DelegateFunctionality.GoodbyeMessage;
            Func<bool, string, string> funcMsg = DelegateFunctionality.IsThisGoodBye;
            
            Console.WriteLine($"{DelegateFunctionality.CountOfListItemsContaining(_names, "A", true)} names start with A");
            Console.WriteLine($"{DelegateFunctionality.CountOfListItemsContaining(_names, "d", false)} names end with D");

            actionMsg("Paul");

            // Display the contents of the list using the Print method.
            _names.ForEach(DelegateFunctionality.Print);

            DelegateFunctionality.AnonymousPrint(_names);
            Console.WriteLine(funcMsg(true, "Paul"));
            Console.WriteLine(funcMsg(false, "Aaron"));

            string result = DelegateFunctionality.AnonymousLessThanTen(5) ? "anonymous less than 10" : "anonymous greater than 10";
            Console.WriteLine(result);

            result = DelegateFunctionality.AnonymousLessThanTen(15) ? "anonymous less than 10" : "anonymous greater than 10";
            Console.WriteLine(result);

            result = DelegateFunctionality.LambdaLessThanTen(5) ? "lambda less than 10" : "lambda greater than 10";
            Console.WriteLine(result);

            result = DelegateFunctionality.LambdaLessThanTen(15) ? "lambda less than 10" : "lambda greater than 10";
            Console.WriteLine(result);
        }
    }
}