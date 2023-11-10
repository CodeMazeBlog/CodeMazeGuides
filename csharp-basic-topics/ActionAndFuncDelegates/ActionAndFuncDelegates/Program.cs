namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var delegatesFunctions = new DelegateExample();

            //Action Delegates
            Action<string> greet = delegatesFunctions.GreetPerson;

            greet("John");
            greet("Peter Parker");


            //Func Delegates
            Func<int, int, int> add = delegatesFunctions.AddNumbers;
            
            var result = add(5, 3);
            Console.WriteLine("Result of 5 + 3 = " + result);
            Console.WriteLine("Result of 6 + 11 = " + add(6, 11));

        }
    }
}
