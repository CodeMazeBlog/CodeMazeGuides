namespace Action_and_Func_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Action Delegates
            Action<string> greet = (name) => Console.WriteLine($"Hello, {name}!");
            greet("John");
            greet("Peter Parker");

            //Func Delegates
            Func<int, int, int> add = (a, b) => a + b;
            int result = add(5, 3); // result is now 8

            Console.WriteLine("Result of 5 + 3 = " + result);
            Console.WriteLine("Result of 6 + 11 = " + add(6, 11));

        }
    }
}
