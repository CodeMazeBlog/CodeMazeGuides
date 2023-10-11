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

            bool ofAge = DelegateFunctionality.IsPersonOfLegalAge(22);
            PrintIsOfAge(ofAge);

            ofAge = DelegateFunctionality.AnonymousIsPersonOfLegalAge(10);
            PrintIsOfAge(ofAge);

            ofAge = DelegateFunctionality.AnonymousIsPersonOfLegalAge(35);
            PrintIsOfAge(ofAge);

            ofAge = DelegateFunctionality.LambdaIsPersonOfLegalAge(10);
            PrintIsOfAge(ofAge);

            ofAge = DelegateFunctionality.LambdaIsPersonOfLegalAge(21);
            PrintIsOfAge(ofAge);
        }

        private static void PrintIsOfAge(bool isOfAge) 
        {
            Console.WriteLine(isOfAge ? "person is of age" : "not old enough");
        }
    }
}