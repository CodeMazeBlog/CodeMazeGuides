using BenchmarkDotNet.Attributes;
using UpdateItemInListCSharp.Models;

namespace UpdateItemInListCSharp
{
    [MemoryDiagnoser(true)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkTester
    {
        private Library _library;

        [Benchmark]
        public void CheckoutBookFind()
        {
            _library.CheckoutBookFind("978-0439708180");
        }

        [Benchmark]
        public void CheckoutBookFindIndex()
        {
            _library.CheckoutBookFindIndex("978-0439708180");
        }

        [Benchmark]
        public void CheckoutBookFirstOrDefault()
        {
            _library.CheckoutBookFirstOrDefault("978-0439708180");
        }

        [Benchmark]
        public void CheckoutBookForeach()
        {
            _library.CheckoutBookForeach("978-0439708180");
        }

        [Benchmark]
        public void CheckoutBookIndexOf()
        {
            _library.CheckoutBookIndexOf(_library.Books[0]);
        }

        [Benchmark]
        public void CheckoutBookSingleOrDefault()
        {
            _library.CheckoutBookSingleOrDefault("978-0439708180");
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _library = new Library();
        }
    }
}
