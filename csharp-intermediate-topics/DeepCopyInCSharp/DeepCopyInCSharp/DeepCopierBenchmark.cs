using BenchmarkDotNet.Attributes;

namespace DeepCopyInCSharp
{
    public class DeepCopierBenchmark
    {
        private Person? _person;

        [GlobalSetup]
        public void Setup()
        {
            _person = new Person
            {
                Name = "John",
                Age = 45,
                Address = new Address
                {
                    Street = "56 Jump St.",
                    City = "Aquatica",
                    State = "TY"
                }
            };
        }

        [Benchmark]
        public Person ICloneableBenchmark()
        {
            return (Person)_person.Clone();
        }

        [Benchmark]
        public Person XMLSerializationBenchmark()
        {
            return DeepCopyMaker.DeepCopyXML(_person);
        }

        [Benchmark]
        public Person JSONSerializationBenchmark()
        {
            return DeepCopyMaker.DeepCopyJSON(_person);
        }

        [Benchmark]
        public Person DataContractSerializationBenchmark()
        {
            return DeepCopyMaker.DeepCopyDataContract(_person);
        }

        [Benchmark]
        public Person ReflectionBenchmark()
        {
            return DeepCopyMaker.DeepCopyReflection(_person);
        }

        [Benchmark]
        public Person ExpressionTreesBenchmark()
        {
            return DeepCopyMaker.DeepCopyExpressionTrees(_person);
        }

        [Benchmark]
        public Person AutoMapperBenchmark()
        {
            return new DeepCopyMaker().DeepCopyAutoMapper(_person);
        }

        [Benchmark]
        public Person FastDeepClonerBenchmark()
        {
            return DeepCopyMaker.DeepCopyFastDeepCloner(_person);
        }

        [Benchmark]
        public Person DeepCopyLibraryBenchmark()
        {
            return DeepCopyMaker.DeepCopyLibraryDeepCopy(_person);
        }

        [Benchmark]
        public Person JsonDotNetBenchmark()
        {
            return DeepCopyMaker.DeepCopyJsonDotNet(_person);
        }
    }
}
