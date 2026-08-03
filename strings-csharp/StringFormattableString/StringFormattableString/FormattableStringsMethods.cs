using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Microsoft.Extensions.Logging;

namespace StringFormattableString
{
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class FormattableStringsMethods
    {
        public IEnumerable<object> StringValues() 
        {
            yield return new object [] { "John", 30 };
        }

        [Benchmark]
        [ArgumentsSource(nameof(StringValues))]
        public string StringExample(string studentName, int studentAge) 
        {
            return $"My name is {studentName} and I am {studentAge} years old.";
        }

        [Benchmark]
        [ArgumentsSource(nameof(StringValues))]
        public FormattableString FormattableStringExample(string studentName, int studentAge) 
        {
            return $"My name is {studentName} and I am {studentAge} years old.";
        }

        public FormattableString FormattableStringDateExample(DateTime currentDate)
        {  
            return $"Today's date: {currentDate:D}";
        }

        public FormattableString FormattableStringLoggingExample(LogLevel level, string message)
        {
            return $"[{DateTime.Now}] [{level}] {message}";
        }

        public FormattableString FormattableStringDynamicStringExample(string itemName, int itemCount)
        {
            var messageTemplate = $"You have {(itemCount > 1 ? "items" : "item")} in your cart.";

            return $"{itemCount}: {itemName}; {messageTemplate}";
        }
    }
}