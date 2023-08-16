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
            var message = $"My name is {studentName} and I am {studentAge} years old.";

            return message;
        }

        [Benchmark]
        public FormattableString FormattableStringExample() 
        {
            var studentName = "John";
            var studentAge = 30;
            FormattableString message = $"My name is {studentName} and I am {studentAge} years old.";

            return message;
        }
    }
}
