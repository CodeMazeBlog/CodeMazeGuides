namespace InitSetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var city = new City("Tokyo", 35.652832, 139.839478);

            Console.WriteLine($"{city.Name}: {city.Latitude}, {city.Longitude}");

            city.ChangeName("Edo");

            Console.WriteLine($"{city.Name}: {city.Latitude}, {city.Longitude}");

            var landmark = new Landmark { Name = "Senso-ji", City = "Tokyo" };
            landmark.Name = "Senso-ji Temple";

            Console.WriteLine($"{landmark.Name} is in {landmark.City}");

            var japan = new Country { Name = "Japan", Capital = "Tokyo" };

            Console.WriteLine($"{japan.Name}: {japan.Capital}");

            var tokyo = new Coordinates(35.652832, 139.839478);
            var tower = tokyo with { Latitude = 35.658581, Longitude = 139.745438 };

            Console.WriteLine(tokyo);
            Console.WriteLine(tower);

            var haneda = new Airport("HND", "Haneda") { Name = "Tokyo International" };

            Console.WriteLine($"{haneda.Code}: {haneda.Name}");
        }
    }
}
