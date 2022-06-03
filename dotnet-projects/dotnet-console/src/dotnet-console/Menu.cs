namespace dotnet_console
{
    public static class Menu
    {
        public static void Run()
        {
            Console.WriteLine("1 - Hello World");
            Console.WriteLine("2 - Ask Name");
            var result = Console.ReadKey();

            switch (result.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Hello, World!");
                    break;

                case ConsoleKey.D2:
                    Console.WriteLine("What is your name?");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Hello, {name}");
                    break;
            }

        }
    }
}
