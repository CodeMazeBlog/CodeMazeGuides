namespace dotnet_console
{
    public static class BasicInputOutput
    {
        public static void HelloWorld()
        {
            Console.WriteLine("Hello, World!");
        }

        public static void AskName()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}");
        }

        public static void ReadSingleCharacter()
        {
            var test = Console.Read();
            var test2 = Console.Read();
            Console.WriteLine(test);
            Console.WriteLine(test2);
        }
    }
}
