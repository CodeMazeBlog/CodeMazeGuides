using System.Globalization;
namespace ActionFuncDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Simple Action Delegate without parameters
            Action test = () => Console.WriteLine("Performing some task");
            test(); // Invoking the action delegate

            // Action Delegate with parameter
            Action<string> greet = lang => Console.WriteLine($"Welcome to {lang} demo!");
            greet("C#"); // Displays: Welcome to C# demo

            // Simple Function Delegate 
            Func<float, float, float> divide = (a, b) => a / b;
            Console.WriteLine(divide(5, 3)); // Displays: 1.666666

            // Another Function Delegate Example
            // Instantiate delegate to reference Titlecase method
            Func<string, string> convertMethod = Titlecase;
            string name = "illinois";
            // Use delegate instance to call Titlecase method
            Console.WriteLine(convertMethod(name));
            Console.ReadKey();
        }

        static string Titlecase(string inputString)
        {
            var textinfo = new CultureInfo("en-US", false).TextInfo;
            return textinfo.ToTitleCase(inputString);
        }
    }
}
