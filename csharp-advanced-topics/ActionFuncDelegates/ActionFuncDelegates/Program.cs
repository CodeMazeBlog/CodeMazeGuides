namespace ActionFuncDelegates
{
    internal class Program
    {
        public delegate void VoidDelegate(string input);
        public delegate int ReturnDelegate(int input);
        static void Main(string[] args)
        {
            VoidDelegate DisplayMessageDelegate = (input) => Console.WriteLine(input);
            DisplayMessageDelegate("I am a custom delegate that takes single parameter");

            ReturnDelegate ReturnValueDelegate = (input) => input * input;
            var result = ReturnValueDelegate(2);
            Console.WriteLine(result.ToString());

            Action<string> DisplayMessageAction = (input) => Console.WriteLine(input);
            DisplayMessageAction("I am Action<T> Delegate");

            Action<string, string> DisplayMessagesAction = (input1, input2) => Console.WriteLine(input1 + input2);
            DisplayMessagesAction("I am Action<T,T> Delegate.", " So I can display many parameters!");

            Func<int, int, int> FuncReturnSumOfTwoNumbers = (a, b) => (a + b);
            Console.WriteLine(FuncReturnSumOfTwoNumbers(2, 3).ToString());

            Func<int, int, int> sum = (a, b) => a + b;
            Func<int, int, int> multiply = (a, b) => a * b;
            DisplayUnknownResult(2, 3, sum);
            DisplayUnknownResult(2, 3, multiply);

            void DisplayUnknownResult(int a, int b, Func<int, int, int> func)
            {
                Console.WriteLine(func(a, b).ToString());
            }
            Console.ReadLine();

            var developers = new List<Developer>
                {
                    new Developer { Name = "John", City = "New York" },
                    new Developer { Name = "Anne", City = "London" },
                    new Developer { Name = "David", City = "Tokyo" }
                };
            //developers.Where    //*used just to get the snippet picture.


        }
        public class Developer
        {
            public string Name { get; set; }
            public string City { get; set; }
        }
    }
}