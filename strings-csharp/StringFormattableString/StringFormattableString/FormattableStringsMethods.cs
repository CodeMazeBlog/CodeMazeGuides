using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace StringFormattableString
{
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class FormattableStringsMethods
    {
        [Benchmark]
        public string StringExample() 
        {
            var studentName = "John";
            var studentAge = 30;

            return $"My name is {studentName} and I am {studentAge} years old.";
        }

        [Benchmark]
        public FormattableString FormattableStringExample() 
        {
            var studentName = "Sean";
            var studentAge = 40;
            
            return $"My name is {studentName} and I am {studentAge} years old.";
        }
    }
}