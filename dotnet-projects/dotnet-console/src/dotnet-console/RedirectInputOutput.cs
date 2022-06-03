namespace dotnet_console
{
    public static class RedirectInputOutput
    {
        // test2.txt must exist
        public static void Run()
        {
            string file = @"c:\tmp\test2.txt";
            using TextWriter tw = File.CreateText(file);

            using TextReader tr = new StreamReader(@"c:\tmp\test.txt");

            Console.SetIn(tr);
            Console.SetOut(tw);

            string result = Console.ReadLine();
            Console.WriteLine(result);
        }
    }
}
