using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterateThroughDictionary
{
    public class PerformAnalysisTest
    {
        private Dictionary<int, string> TestValues = new Dictionary<int, string>();

        private void FillData()
        {
            for (int i = 0; i < 100000; i++)
            {
                TestValues.Add(i, "value-" + i);
            }
        }

        public void TestDictionaryLoopResult()
        {
            FillData();
            WhenDictionaryUsingForEach(TestValues);
            WhenDictionaryUsingForLoop(TestValues);
            WhenDictionaryParallelEnumerable(TestValues);
            WhenDictionaryJoinString(TestValues);
        }

        private void WhenDictionaryUsingForEach(Dictionary<int, string> TestValues)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var result = 0;
            foreach (int i in TestValues.Keys)
            {
                result += i;
            }
            watch.Stop();

            Console.WriteLine($"Dictionary using ForEach loop - { watch.Elapsed} ms");
        }

        private void WhenDictionaryUsingForLoop(Dictionary<int, string> TestValues)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var result = 0;
            for (int i = 0; i < TestValues.Count; i++)
            {
                result = i + 1 ;

            }
            watch.Stop();

            Console.WriteLine($"Dictionary using For loop - {watch.Elapsed} ms");
        }

        private void WhenDictionaryParallelEnumerable(Dictionary<int, string> TestValues)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            TestValues.AsParallel()
                      .ForAll(val => val.Key.ToString());
            watch.Stop();
            
            Console.WriteLine($"Dictionary using Parallel Enumerable - {watch.Elapsed} ms");
        }

        private void WhenDictionaryJoinString(Dictionary<int, string> TestValues)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            var resultstring = (String.Join(Environment.NewLine, TestValues));
            watch.Stop();

            Console.WriteLine($"Dictionary using String Join - {watch.Elapsed} ms");
        }
    }
}
