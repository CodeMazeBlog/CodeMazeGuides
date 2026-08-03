using BenchmarkDotNet.Attributes;
using JObjectToDictionary;
using Newtonsoft.Json.Linq;


namespace ConvertJObjectToDictionaryBenchmark
{
    public class ToDictionaryBenchmark
    {
        JObject person = new(
            new JProperty("Name", "John Smith"),
            new JProperty("BirthDate", new DateTime(1983, 3, 20)),
            new JProperty("Hobbies", new JArray("Play football", "Programming")),
            new JProperty("Extra", new JObject(
                new JProperty("Age", 27),
                new JProperty("Phone", new JArray(1, 2, 3))
            ))
        );

        [Benchmark]
        public void ToDictionaryUsingTraditionalIteration() => JObjectConverter.ConvertJObjectToDictionary(person);

        [Benchmark]
        public void ToDictionaryUsingJsonNet() => JObjectConverter.ConvertUsingNewtonsoftJson(person);

        [Benchmark]
        public void ToDictionaryUsingLinq() => JObjectConverter.ConvertUsingLinq(person);

        [Benchmark]
        public void ToDictionaryUsinExtensionMethod() => person.ToDictionary();
    }
}
