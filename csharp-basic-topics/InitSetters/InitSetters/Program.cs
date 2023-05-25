namespace InitSetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var city = new City("Tokyo", 139.839478, 35.652832);

            Console.WriteLine($"{city.Name}: {city.Latitude}, {city.Longitude}");

            city.ChangeName("Edo");

            Console.WriteLine($"{city.Name}: {city.Latitude}, {city.Longitude}");
        }
    }
}