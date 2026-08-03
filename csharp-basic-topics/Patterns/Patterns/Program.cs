namespace Patterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var run = true;
            while (run)
            {
                Matching();
                Console.WriteLine($"{Environment.NewLine} Run Again? (Y/N)");
                var input = Console.ReadLine() ?? "";
                run = input.ToLower().First().Equals('y');
            }
        }

        public static void Matching()
        {
            var message = MatchTypePattern(new Cat());
            Console.WriteLine(message);
            var name = MatchConstantPattern("Bark");
            Console.WriteLine(name);

            int? numberOfAnimals = 1;
            if(numberOfAnimals is not null) message = MatchRelationalPattern(numberOfAnimals);
            Console.WriteLine(message);

            message = MatchLogicalPattern(20);
            Console.WriteLine(message);
            var isDog = MatchPropertyPattern(new Dog());
            Console.WriteLine(isDog);
            message = MatchPositionalPattern(50, 10000);
            Console.WriteLine(message);
            var cloned = MatchVarPattern(new Dog());
            Console.WriteLine(cloned);
        }
        public static string MatchTypePattern(Animal animal) => animal switch
        {
            Cat => "Meow",
            Dog => "Bark",
            null => "Please Provide A Non-Null Animal Object!",
            _ => $"Unknown Animal {nameof(animal)}!"
        };

        public static string MatchConstantPattern(string animalmessage) => animalmessage switch
        {
            "Meow" => "Cat",
            "Bark" => "Dog",
            null => "Please Provide A Non-Null Message!",
            _ => $"Unknown Animal Message {animalmessage}!"
        };

        public static string MatchRelationalPattern(int? animalcount) => animalcount switch
        {
            < 1000 => "Less than one thousand animals",
            >= 1000 => "Greater than or equal to one thousand animals"
        };

        public static string MatchLogicalPattern(int animalage) => animalage switch
        {
            0 or (> 0 and < 5) => "Baby animal",
            >= 5 and <= 13 => "Child animal",
            > 13 and < 20 => "Teenage animal",
            >= 20 and < 60 => "Adult animal",
            >= 60 => "Senior animal",
            _ => "Unborn animal"
        };

        public static bool MatchPropertyPattern(Animal animal) => animal is
        {
            Name: "Dog", Description: "furry animal with tail and paws", Cloned: false or true
        };

        public static string MatchPositionalPattern(int animalage, int animalweight) => (animalage, animalweight) switch
        {
            ( <= 20, <= 50) => "Healthy young animal weight",
            ( <= 20, > 50) => "Unhealthy young animal weight",
            ( >= 21, <= 100) => "Healthy adult animal weight",
            ( >= 21, > 100) => "Unhealthy adult animal weight"
        };

        public static bool MatchVarPattern(Animal animal) => 
            animal.CreateClone() is var clone 
            && clone.Clone 
            && animal.Cloned
            && animal.GetType() == clone.GetType();
    }
}