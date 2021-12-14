using AsAndIsOperatorsInCSharp;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("When strictly comparing types using both '==' and 'is' operators:");
            EqualityVsTypeComparison();

            Console.WriteLine("Is a Cow an Animal if doing a '==' type comparison? And doing an 'is' type comparison?");
            IsCowAnAnimal();

            Console.WriteLine("Can a Cow be converted to an Animal type object using the 'as' operator?");
            CanCowBeAsAnimal();

            Console.WriteLine("And what if we try to convert a generic object to an Animal using 'as'?");
            CanObjectBeAsCow();

            Console.WriteLine("Testing null values is easy with 'is':");
            Console.WriteLine(HumanFriendlyNullCheck(new object()));

            AsVsCastInvalidHandling();
        }

        public static void EqualityVsTypeComparison()
        {
            var example = "This is a string";

            var equalityComparison = example.GetType() == typeof(string);
            var typeComparison = example is string;

            if (equalityComparison && typeComparison)
            {
                Console.WriteLine("Both comparisons are valid");
            }
            else
            {
                Console.WriteLine("The comparisons didn't evaluate the same way");
            }
        }

        public static void IsCowAnAnimal()
        {
            var bessie = new Cow();

            Console.WriteLine(bessie.GetType() == typeof(Animal));
            Console.WriteLine(bessie is Animal);
        }

        public static void CanCowBeAsAnimal()
        {
            var bessie = new Cow();
            Animal bessieAnimal = bessie as Animal;

            Console.WriteLine(bessieAnimal is not null);
        }

        public static void CanObjectBeAsCow()
        {
            var imNotACow = new object();
            var notBessie = imNotACow as Cow;

            Console.WriteLine(notBessie is null ? "The object is null" : "The object is not null");
        }

        public static string HumanFriendlyNullCheck(object obj)
        {
            return obj is null ? $"This {typeof(object)} is null" : $"This {typeof(object)} is not null";
        }

        public static void AsVsCastInvalidHandling()
        {
            var imNotACow = new object();

            var notBessieAs = imNotACow as Cow;
            if (notBessieAs is null)
            {
                Console.WriteLine("This verifies that a conversion was not valid using an 'as' operator");
            }

            try
            {
                var notBessieCast = (Cow)imNotACow;
            }
            catch (Exception)
            {
                Console.WriteLine("This verifies that a conversion was not valid using a cast expression");
            }
        }
    }
}
