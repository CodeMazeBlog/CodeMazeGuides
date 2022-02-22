using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IterateThroughDictionary
{
    public class PerformAnalysisTest
    {
        private Dictionary<int, string> testValues = new Dictionary<int, string>();

        private void FillData()
        {
            for (int i = 0; i < 100000; i++)
            {
                testValues.Add(i, "value-" + i);
            }
        }

        public void TestDictionaryLoopResult()
        {
            FillData();
            WhenDictionaryUsingForEach(testValues);
            WhenDictionaryUsingForLoop(testValues);
            WhenDictionaryParallelEnumerable(testValues);
            WhenDictionaryJoinString(testValues);
        }

        private void WhenDictionaryUsingForEach(Dictionary<int, string> testValues)
        {
            var watch = new Stopwatch();
            watch.Start();

            var result = 0;
            foreach (int i in testValues.Keys)
            {
                result += i;
            }
            watch.Stop();

            Console.WriteLine($"Dictionary using ForEach loop - { watch.Elapsed} ms");
        }

        private void WhenDictionaryUsingForLoop(Dictionary<int, string> testValues)
        {
            var watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < testValues.Count; i++)
            {
                var result = testValues[i].Length + 1;
            }
            watch.Stop();

            Console.WriteLine($"Dictionary using For loop - {watch.Elapsed} ms");
        }

        private void WhenDictionaryParallelEnumerable(Dictionary<int, string> testValues)
        {
            var watch = new Stopwatch();
            watch.Start();

            testValues.AsParallel()
                      .ForAll(val => val.Key.ToString());
            watch.Stop();
            
            Console.WriteLine($"Dictionary using Parallel Enumerable - {watch.Elapsed} ms");
        }

        private void WhenDictionaryJoinString(Dictionary<int, string> testValues)
        {
            var watch = new Stopwatch();
            watch.Start();
            
            var resultstring = (String.Join(Environment.NewLine, testValues));
            watch.Stop();

            Console.WriteLine($"Dictionary using String Join - {watch.Elapsed} ms");
        }
    }
}
