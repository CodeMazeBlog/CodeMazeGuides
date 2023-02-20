namespace SmartEnum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dev = new Developer("John", DeveloperLevel.Senior);

            Console.WriteLine($"{dev.Name} is a {dev.Level} developer.");
            Console.WriteLine($"{dev.Name}'s productivity is {dev.Level.Productivity} lines/hour.");
            Console.WriteLine($"The developer can write 500 lines of code in {dev.WriteCode(500):F2} hours.");
        }
    }
}