using System;
using Xunit;
using static ActionAndFunc.Program;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void whenUsingSimpleSummarizers_thenTheSummaryIsCorrect()
        {
            var numbers = new double[] { 1, 2, 3, 4 };

            _Assert(10, (x, y) => x + y);
            _Assert(24, (x, y) => x * y);

            void _Assert(double expected, Func<double, double, double> summarizer) => Assert.Equal(expected, Summary(numbers, summarizer));
        }

        [Fact]
        public void givenSomeInputs_whenConverted_thenTheyAreConvertedSuccessfully()
        {
            _Assert("SUM", "PRINT", new double[] { 1.3, 2.2 }, new[] { "Sum", "Print", "1.3", "2.2" });
            _Assert("MUL", "SAVE", new double[] { 3.1, 6.55, -2.76 }, new[] { "mul", "sAvE", "3.1", "6.55", "-2.76" });
            _Assert("SQR", "DOSOMETHING", new double[] { 11, 13 }, new[] { "sqr", "DoSomething", "11", "12a", "13" });

            void _Assert(string function, string action, double[] numbers, string[] inputs)
            {
                var (f, a, n) = ProcessInputs(inputs);
                Assert.Equal(function, f);
                Assert.Equal(action, a);
                Assert.Equal<double>(numbers, n);
            }
        }

        [Fact]
        public void whenInputIsValid_thenReturnsZero()
        {
            _Assert(new[] { "Sum", "Print", "1.3", "2.2" });
            _Assert(new[] { "mul", "sAvE", "3.1", "6.55", "-2.76" });
            _Assert(new[] { "sqr", "print", "11", "12a", "13" });

            void _Assert(string[] inputs) => Assert.Equal(0, Main(inputs));
        }

        [Fact]
        public void whenInputIsNotValid_thenReturnsMinus1()
        {
            _Assert(new[] { "Sumo", "Print", "1.3", "2.2" });
            _Assert(new[] { "mul", "DoSomething", "3.1", "6.55", "-2.76" });
            _Assert(new[] { "sqr", "print" });

            void _Assert(string[] inputs) => Assert.Equal(-1, Main(inputs));
        }
    }
}
