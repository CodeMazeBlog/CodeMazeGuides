namespace Action.Delegate.Lambda
{
    internal class Program 
    { 
        static void Main(string[] args) 
        { 
            Action<int, int> addDelegate = (int value1, int value2) => 
            { 
                Console.WriteLine($"The addition of {value1} and {value2} is:{value1 + value2}"); }; addDelegate(1, 2); 
        } 
    }
}