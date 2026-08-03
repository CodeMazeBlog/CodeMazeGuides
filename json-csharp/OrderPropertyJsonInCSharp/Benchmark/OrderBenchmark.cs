using BenchmarkDotNet.Attributes;
using OrderPropertyJsonInCSharp.Converters;
using OrderPropertyJsonInCSharp.Models;
using OrderPropertyJsonInCSharp.Resolvers;
using OrderPropertyJsonInCSharp.Serializers;

namespace Benchmark
{
    public class OrderBenchmark
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

        [Benchmark]
        public void PropertyOrderUsingSystemTextJson()
        {
            MicrosoftSerializer.Serialize(Car);
        }

        [Benchmark]
        public void PropertyOrderUsingNewtonsoftJson()
        {
            NewtonsoftSerializer.Serialize(Car);
        }

        [Benchmark]
        public void PropertyConverterUsingSystemTextJson()
        {
            MicrosoftSerializer.Serialize(Animal, new MicrosoftOrderedPropertiesConverter<Animal>());
        }

        [Benchmark]
        public void PropertyConverterUsingNewtonsoftJson()
        {
            NewtonsoftSerializer.Serialize(Animal, new NewtonsoftOrderedPropertiesConverter<Animal>());
        }

        [Benchmark]
        public void TypeInfoResolverUsingSystemTextJson()
        {
            MicrosoftSerializer.Serialize(Animal, new OrderedPropertiesJsonTypeInfoResolver());
        }

        [Benchmark]
        public void ContractResolverUsingNewtonsoftJson()
        {
            NewtonsoftSerializer.Serialize(Animal, new OrderedPropertiesContractResolver());
        }
    }
}
