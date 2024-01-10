using System.Globalization;
namespace ActionFuncDelegates
{
    public static class Program
    {
        public static Action<string> Greet = lang => Console.WriteLine($"Welcome to {lang} demo!");

        public static Func<float, float, float> Divide = (a, b) => a / b;

        public static Func<string, string> ConvertMethod = Titlecase;
       
        static void Main(string[] args)
        {
            Action Test = () => Console.WriteLine("Performing some task");
            Test(); 
            
            Greet("C#"); // Displays: Welcome to C# demo       
            
            Console.WriteLine(Divide(5, 3)); 
            
            var name = "illinois";
                        
            Console.WriteLine(ConvertMethod(name));
            Console.ReadKey();
        }

        public static string Titlecase(string inputString)
        {
            var textinfo = new CultureInfo("en-US", false).TextInfo;
            
            return textinfo.ToTitleCase(inputString);
        }
    }
}
