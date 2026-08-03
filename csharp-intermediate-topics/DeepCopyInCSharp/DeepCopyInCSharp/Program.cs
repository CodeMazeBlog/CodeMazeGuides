using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace DeepCopyInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Benchmark - start
            var config = ManualConfig.Create(DefaultConfig.Instance)
                                     .WithOptions(ConfigOptions.DisableOptimizationsValidator);

            var summary = BenchmarkRunner.Run<DeepCopierBenchmark>(config);
            Console.WriteLine(summary);
            //Benchmark - end

            var originalPerson = new Person
            {
                Name = "Steve Doe",
                Age = 21,
                Address = new Address
                {
                    Street = "123 Main St.",
                    City = "Anytown",
                    State = "AB"
                }
            };

            //Shallow Copy
            var copiedPerson = originalPerson.ShallowCopy();

            //Deep Copy - ICloneable
            copiedPerson = (Person)originalPerson.Clone();

            //Deep Copy - XML Serializer
            copiedPerson = DeepCopyMaker.DeepCopyXML(originalPerson);

            //Deep Copy - JSON Serialzer
            copiedPerson = DeepCopyMaker.DeepCopyJSON(originalPerson);

            //Deep Copy - Data Contract Serialization
            copiedPerson = DeepCopyMaker.DeepCopyDataContract(originalPerson);

            //Deep Copy - Reflection
            copiedPerson = DeepCopyMaker.DeepCopyReflection(originalPerson);

            //Deep Copy - Expression Trees
            copiedPerson = DeepCopyMaker.DeepCopyExpressionTrees(originalPerson);

            //Deep Copy - AutoMapper
            var copier = new DeepCopyMaker();
            copiedPerson = copier.DeepCopyAutoMapper(originalPerson);

            //Deep Copy - FastDeepCloner
            copiedPerson = DeepCopyMaker.DeepCopyFastDeepCloner(originalPerson);

            //Deep Copy - DeepCopy
            copiedPerson = DeepCopyMaker.DeepCopyLibraryDeepCopy(originalPerson);

            //Deep Copy - JSON.Net
            copiedPerson = DeepCopyMaker.DeepCopyJsonDotNet(originalPerson);

            //Modifying the copied object
            copiedPerson.Name = "Jack Swallow";
            copiedPerson.Address.Street = "456 Elmo St.";

            //Result
            Console.WriteLine($"Original Name: {originalPerson.Name}");
            Console.WriteLine($"Original Street: {originalPerson.Address.Street}");
        }
    }
}