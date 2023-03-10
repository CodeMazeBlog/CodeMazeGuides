using BenchmarkDotNet.Running;

namespace DeepCopyInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Benchmark - start
            var summary = BenchmarkRunner.Run<DeepCopierBenchmark>();
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
            var copiedPerson = originalPerson;

            //Deep Copy - ICloneable
            copiedPerson = (Person)originalPerson.Clone();

            //Deep Copy - XML Serializer
            copiedPerson = DeepCopier.DeepCopyXML(originalPerson);

            //Deep Copy - JSON Serialzer
            copiedPerson = DeepCopier.DeepCopyJSON(originalPerson);

            //Deep Copy - Data Contract Serialization
            copiedPerson = DeepCopier.DeepCopyDataContract(originalPerson);

            //Deep Copy - Reflection
            copiedPerson = DeepCopier.DeepCopyReflection(originalPerson);

            //Deep Copy - Expression Trees
            copiedPerson = DeepCopier.DeepCopyExpressionTrees(originalPerson);

            //Modifying the copied object
            copiedPerson.Name = "Jack Swallow";
            copiedPerson.Address.Street = "456 Elmo St.";

            //Result
            Console.WriteLine($"Original Name: {originalPerson.Name}");
            Console.WriteLine($"Original Street: {originalPerson.Address.Street}");
        }
    }
}