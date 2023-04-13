using OrderPropertyJsonInCSharp.Converters;
using OrderPropertyJsonInCSharp.Models;
using OrderPropertyJsonInCSharp.Resolvers;
using OrderPropertyJsonInCSharp.Serializers;
using System.Reflection;

namespace OrderPropertyJsonInCSharp
{
    public static class Program
    {
        public static Car Car => new()
        {
            NumberOfDoors = 4,
            Manufacturer = "Fiat",
            Id = 1
        };

        public static Animal Animal => new()
        {
            Id = 1,
            Name = "Miau",
            Age = 3
        };

        public static void Main(string[] args)
        {
            // Default Order
            var properties = typeof(Student)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToList();

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name} {property.MetadataToken}");
            }

            // Using Property Order
            var json = MicrosoftSerializer.Serialize(Car);
            Console.WriteLine(json);

            json = NewtonsoftSerializer.Serialize(Car);
            Console.WriteLine(json);

            // Using JsonConverter
            json = MicrosoftSerializer.Serialize(Animal, new MicrosoftOrderedPropertiesConverter<Animal>());
            Console.WriteLine(json);

            json = NewtonsoftSerializer.Serialize(Animal, new NewtonsoftOrderedPropertiesConverter<Animal>());
            Console.WriteLine(json);

            // Using DefaultContractResolver
            json = NewtonsoftSerializer.Serialize(Animal, new OrderedPropertiesContractResolver());
            Console.WriteLine(json);

            // Using DefaultJsonTypeInfoResolver
            json = MicrosoftSerializer.Serialize(Animal, new OrderedPropertiesJsonTypeInfoResolver());
            Console.WriteLine(json);
        }
    }
}
