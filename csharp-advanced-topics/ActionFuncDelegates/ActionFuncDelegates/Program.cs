namespace ActionFuncDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomDelegates customDelegate = new CustomDelegates();

            customDelegate.DisplayMessage("I am a custom delegate that takes single parameter");

            var result = customDelegate.ReturnValue(2);
            Console.WriteLine(result.ToString());

            ActionDelegate actionDelegate = new ActionDelegate();

            actionDelegate.DisplayMessage("I am Action<T> Delegate");
            actionDelegate.DisplayMessages("I am Action<T,T> Delegate.", " So I can display many parameters!");

            FuncDelegate funcDelegate = new FuncDelegate();

            DisplayUnknownResult(2, 3, funcDelegate.Sum);
            DisplayUnknownResult(2, 3, funcDelegate.Multiply);

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
    }
}