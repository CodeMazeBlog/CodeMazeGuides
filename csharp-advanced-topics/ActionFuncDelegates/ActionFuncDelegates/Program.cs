using System.Globalization;
namespace ActionFuncDelegates
{
    public static class Program
    {
        // Action Delegate with parameter
        public static Action<string> greet = lang => Console.WriteLine($"Welcome to {lang} demo!");

        // Simple Function Delegate
        public static Func<float, float, float> divide = (a, b) => a / b;

        // Another Function Delegate
        public static Func<string, string> convertMethod = Titlecase;
        static void Main(string[] args)
        {
         
            Action test = () => Console.WriteLine("Performing some task");
            test(); 
            
            greet("C#"); // Displays: Welcome to C# demo           
            
            
            Console.WriteLine(divide(5, 3)); 
            
            string name = "illinois";
            
            
            Console.WriteLine(convertMethod(name));
            Console.ReadKey();
        }

        public static string Titlecase(string inputString)
        {
            var textinfo = new CultureInfo("en-US", false).TextInfo;
            return textinfo.ToTitleCase(inputString);
        }
    }
}
