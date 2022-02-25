using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace BenchmarkRunner
{
    public class DictionaryIterateBenchmark
    {
        private Dictionary<int, string> _testValues = new Dictionary<int, string>();

        private void FillData()
        {
            for (int i = 0; i < 100000; i++)
            {
                _testValues.Add(i, "value-" + i);
            }
        }
        public void TestDictionaryLoopResult()
        {
            FillData();
            WhenDictionaryUsingForEach();
            WhenDictionaryUsingForLoop();
            WhenDictionaryParallelEnumerable();
            WhenDictionaryJoinString();
        }

        [Benchmark]
        public void WhenDictionaryUsingForEach()
        {
            var result = 0;

            foreach (int i in _testValues.Keys)
            {
                result += i;
            }
        }

        [Benchmark]
        public void WhenDictionaryUsingForLoop()
        {
            for (int i = 0; i < _testValues.Count; i++)
            {
                var result = _testValues[i].Length + 1;
            }
        }

        [Benchmark]
        public void WhenDictionaryParallelEnumerable()
        {
            _testValues.AsParallel()
                      .ForAll(val => val.Key.ToString());
        }

        [Benchmark]
        public void WhenDictionaryJoinString()
        {
            var resultstring = (String.Join(Environment.NewLine, _testValues));
        }
    }
}
