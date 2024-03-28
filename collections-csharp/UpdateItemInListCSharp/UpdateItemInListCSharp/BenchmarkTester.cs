using BenchmarkDotNet.Attributes;

namespace UpdateItemInListCSharp
{
    [MemoryDiagnoser(true)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkTester
    {
        private Library _library = new Library();

        [Benchmark]
        public void CheckoutBookUsingFind()
        {
            _library.CheckoutBookUsingFind("978-0439708180");
        }

        [Benchmark]
        public void CheckoutBookUsingFindIndex()
        {
            _library.CheckoutBookUsingFindIndex("978-0439708180");
        }

        [Benchmark]
        public void CheckoutBookUsingFirstOrDefault()
        {
            _library.CheckoutBookUsingFirstOrDefault("978-0439708180");
        }

        [Benchmark]
        public void CheckoutBookUsingForeach()
        {
            _library.CheckoutBookUsingForeach("978-0439708180");
        }

        [Benchmark]
        public void CheckoutBookUsingIndexOf()
        {
            _library.CheckoutBookUsingIndexOf(_library.Books[0]);
        }

        [Benchmark]
        public void CheckoutBookUsingSingleOrDefault()
        {
            _library.CheckoutBookUsingSingleOrDefault("978-0439708180");
        }
    }
}
