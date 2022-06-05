using System.Reflection;

namespace dotnet_console
{
    public static class RedirectInputOutput
    {        
        public static void Run()
        {
            var outputLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var file = $"{outputLocation}/SampleFile/test.txt";
            
            using TextWriter tw = File.CreateText(file);
            using TextReader tr = new StreamReader($"{outputLocation}/SampleFile/test2.txt");

            Console.SetIn(tr);
            Console.SetOut(tw);

            string result = Console.ReadLine();
            Console.WriteLine(result);
        }
    }
}
