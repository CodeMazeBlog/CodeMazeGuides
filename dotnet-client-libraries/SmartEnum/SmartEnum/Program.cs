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

            var juniorFromName = DeveloperLevel.FromName("Junior");
            var juniorFromValue = DeveloperLevel.FromValue(1);

            Console.WriteLine(juniorFromName == juniorFromValue);

            if (DeveloperLevel.TryFromName("Regular", out var regularFromName))
            {
                Console.WriteLine($"Created enumeration from name: {regularFromName.Name}");
            }

            if (DeveloperLevel.TryFromValue(2, out var regularFromValue))
            {
                Console.WriteLine($"Created enumeration from value: {regularFromValue.Name}");
            }

            Console.WriteLine($"The {nameof(DeveloperLevel)} has {DeveloperLevel.List.Count} different enumerations:");

            foreach (var enumeration in DeveloperLevel.List)
            {
                Console.WriteLine(enumeration.Name);
            }
        }
    }
}