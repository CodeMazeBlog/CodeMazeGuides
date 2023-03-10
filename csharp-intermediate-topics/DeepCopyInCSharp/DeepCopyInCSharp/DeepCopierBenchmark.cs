using BenchmarkDotNet.Attributes;

namespace DeepCopyInCSharp
{
    public class DeepCopierBenchmark
    {
        private Person _person;

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
            return DeepCopier.DeepCopyXML(_person);
        }

        [Benchmark]
        public Person JSONSerializationBenchmark()
        {
            return DeepCopier.DeepCopyJSON(_person);
        }

        [Benchmark]
        public Person DataContractSerializationBenchmark()
        {
            return DeepCopier.DeepCopyDataContract(_person);
        }

        [Benchmark]
        public Person ReflectionBenchmark()
        {
            return DeepCopier.DeepCopyReflection(_person);
        }

        [Benchmark]
        public Person ExpressionTreesBenchmark()
        {
            return DeepCopier.DeepCopyExpressionTrees(_person);
        }
    }
}
