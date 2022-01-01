using System;

namespace CodeMaz
{
    class Program
    {
        static string Capitalize(string s)
        {
            return s.ToUpper();
        }
        static void Main(string[] args)
        {
            var capitalizFunc = new Func<string, string>(Capitalize);
            var anonymousCapitalizFunc = new Func<string, string>(s => s.ToUpper());
            Console.WriteLine(capitalizFunc("Hello World!"));
            Console.WriteLine(anonymousCapitalizFunc("Hello World!"));
        }

    }
}
