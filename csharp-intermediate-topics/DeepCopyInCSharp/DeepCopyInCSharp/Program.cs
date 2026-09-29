using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace DeepCopyInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Benchmark - start
            // FastDeepCloner 1.3.6 ships an assembly built without optimizations, and BenchmarkDotNet
            // refuses to run while any referenced assembly is non-optimized. This switch turns that
            // check off for every assembly, so always run this project with -c Release.
            var config = ManualConfig.Create(DefaultConfig.Instance)
                                     .WithOptions(ConfigOptions.DisableOptimizationsValidator);

            var summary = BenchmarkRunner.Run<DeepCopierBenchmark>(config);
            Console.WriteLine(summary);
            //Benchmark - end

            //Shallow Copy
            CopyModifyAndPrint("Shallow copy (MemberwiseClone)", original => original.ShallowCopy());

            //Deep Copy - ICloneable
            CopyModifyAndPrint("ICloneable", original => (Person)original.Clone());

            //Deep Copy - Copy Constructor
            CopyModifyAndPrint("Copy constructor", original => new Person(original));

            //Deep Copy - XML Serializer
            CopyModifyAndPrint("XML serialization", DeepCopyMaker.DeepCopyXML);

            //Deep Copy - JSON Serializer
            CopyModifyAndPrint("JSON serialization", DeepCopyMaker.DeepCopyJSON);

            //Deep Copy - Data Contract Serialization
            CopyModifyAndPrint("Data contract serialization", DeepCopyMaker.DeepCopyDataContract);

            //Deep Copy - Reflection
            CopyModifyAndPrint("Reflection", DeepCopyMaker.DeepCopyReflection);

            //Deep Copy - Expression Trees
            CopyModifyAndPrint("Expression trees", DeepCopyMaker.DeepCopyExpressionTrees);

            //Deep Copy - FastDeepCloner
            CopyModifyAndPrint("FastDeepCloner", DeepCopyMaker.DeepCopyFastDeepCloner);

            //Deep Copy - DeepCopy
            CopyModifyAndPrint("DeepCopy", DeepCopyMaker.DeepCopyLibraryDeepCopy);

            //Deep Copy - JSON.Net
            CopyModifyAndPrint("Json.NET", DeepCopyMaker.DeepCopyJsonDotNet);
        }

        // Each technique gets a fresh original, so one technique's result
        // can never be hidden behind the next one's.
        private static void CopyModifyAndPrint(string technique, Func<Person, Person> copy)
        {
            var originalPerson = new Person
            {
                Name = "Steve Doe",
                Age = 22,
                Address = new Address
                {
                    Street = "123 Main St.",
                    City = "Anytown",
                    State = "AB"
                }
            };

            var copiedPerson = copy(originalPerson);

            //Modifying the copied object
            copiedPerson.Name = "Jack Swallow";
            copiedPerson.Address.Street = "456 Elmo St.";

            //Result
            Console.WriteLine(technique);
            Console.WriteLine($"Original Name: {originalPerson.Name}");
            Console.WriteLine($"Original Street: {originalPerson.Address.Street}");
            Console.WriteLine();
        }
    }
}