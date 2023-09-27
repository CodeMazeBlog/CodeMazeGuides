namespace Action.Delegate
{
    internal class Program 
    { 
        static void Main(string[] args) 
        { 
            Action<int, int> addDelegate = AddNumbers; addDelegate(1, 2); 
        } 
        static void AddNumbers(int value1, int value2) 
        { 
            Console.WriteLine($"The addition of {value1} and {value2} is:{value1 + value2}"); 
        } 
    }
}