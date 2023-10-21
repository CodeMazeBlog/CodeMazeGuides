using System.Text;

namespace FuncAndActionDelegatesInCSharp
{
    public static class Utilities
    {        
        // Methods to be referenced
        public static string RepeatWord(string word, int reps)
        {
            return new StringBuilder(word.Length * reps + reps - 1)
                .Insert(0, word + " ", reps)
                .ToString();
        }

        static void Bark()
        {
            Console.WriteLine("woof woof");
        }

        static void Greet(string name)
        {
            Console.WriteLine($"Hey, {name}!");
        }

        static string DescribePerson(string name, string adjective, bool hasFeature)
        {
            return $"{name} is {(hasFeature ? "rather " : "not very ")}{adjective}.";
        }

        static string DescribeBook(string author, string adjective, bool isGood)
        {
            return $"{author}'s latest book is quite {adjective} {(isGood ? "and pretty good" : "but not to my taste")}.";
        }

        // Func delegate
        public static void UseFuncDelegateToRepeatWord()
        {
            Func<string, int, string> GenerateText = RepeatWord;
            Console.WriteLine(GenerateText("delegate", 4));
        }
                
        // Action delegate
        public static void UseNonGenericActionToBark()
        {
            Action MakeSound = Bark;
            MakeSound();
        }
                
        public static void UseGenericActionToGreet()
        {
            Action<string> BePolite = Greet;
            BePolite("Jennifer");
        }

        // Instantiation
        public static void UseLongNewKeywordInstantiation()
        {
            Action<string> BePolite = new Action<string>(Greet);
            BePolite("Jennifer");
        }

        public static void UseShortNewKeywordInstantiation()
        {
            Action<string> BePolite = new(Greet);
            BePolite("Jennifer");
        }

        public static void UseAnonymousMethodInstantiation()
        {
            Action<string> BePolite = delegate (string name)
            {
                Console.WriteLine($"Hey, {name}!");
            };

            BePolite("Jennifer");
        }

        public static void UseLambdaExpressionInstantiation()
        {
            Action<string> BePolite = (string name) => Console.WriteLine($"Hey, {name}!");
            BePolite("Jennifer");
        }

        // Delegates as arguments
        static void GenerateGreeting(Action<string> action, string name)
        {
            action(name);
        }

        public static void UseActionAsArgument()
        {
            GenerateGreeting(Greet, "Michael");
        }

        static void GenerateDescription(
            Func<string, string, bool, string> func,
            string name, 
            string adjective, 
            bool hasFeature)
        {
            Console.WriteLine($"What can I say about {name}? Well, {func(name, adjective, hasFeature)}");
        }

        public static void UseFuncAsArgument()
        {
            GenerateDescription(DescribePerson, "Trevor", "lazy", true);
            GenerateDescription(DescribePerson, "Greta", "tall", false);
        }

        public static void UseDynamicMethodAssignment()
        {
            string author = "Danny";
            string question = "Hey, if you need information about the author, enter D."
                + "\nIf you need information about his latest book enter anything else: ";

            Console.WriteLine(question);

            string topic = Console.ReadLine().ToLower();

            Func<string, string, bool, string> GenerateDescription = topic == "d"
                ? DescribePerson : DescribeBook;

            Console.WriteLine(GenerateDescription("Danny", "mysterious", true));
            Console.WriteLine(GenerateDescription("Danny", "popular", false));
        }
    }
}
