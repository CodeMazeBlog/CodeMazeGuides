using BenchmarkDotNet.Attributes;
using CopyArrayElements;

namespace BenchmarkRunner
{
    public class ElementCopierBenchmark
    {
        Article[] benchMarkSourceArray = Enumerable.Repeat(new Article { Title = "Title", LastUpdate = DateTime.Now }, 10000).ToArray();
        private static readonly ElementCopier elementCopier = new ElementCopier();

        [Benchmark]
        public void CopyUsingAssignment()
        {
            elementCopier.CopyUsingAssignment(benchMarkSourceArray);
        }

        [Benchmark]
        public void CopyUsingArrayClass()
        {
            elementCopier.CopyUsingArrayClass(benchMarkSourceArray);
        }

        [Benchmark]
        public void CopyUsingClone()
        {
            elementCopier.CopyUsingClone(benchMarkSourceArray);
        }

        [Benchmark]
        public void CopyUsingCopyTo()
        {
            elementCopier.CopyUsingCopyTo(benchMarkSourceArray);
        }

        [Benchmark]
        public void CopyUsingRange()
        {
            elementCopier.CopyUsingRange(benchMarkSourceArray);
        }

        [Benchmark]
        public void CopyUsingLinq()
        {
            elementCopier.CopyUsingLinq(benchMarkSourceArray);
        }

        [Benchmark]
        public void ManuallyCopy()
        {
            elementCopier.ManuallyCopy(benchMarkSourceArray);
        }
    }
}
