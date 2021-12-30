using System;
using Xunit;

namespace Tests
{
    public class TuplesUnitTest
    {
        [Theory]
        [InlineData(20)]
        [InlineData(46)]
        [InlineData(92)]
        public void givenReturnATuple_WhenExecutedWithAnEvenNum_ReturnsATupleWithATrueValue(int num)
        {
            var tupleOne = Program.ReturnATuple(num);

            Assert.IsType<Tuple<bool, string, int[]>>(tupleOne);

            Assert.True(tupleOne.Item1);
            Assert.Contains("is even", tupleOne.Item2);
        }

        [Theory]
        [InlineData(21)]
        [InlineData(47)]
        [InlineData(93)]
        public void givenReturnATuple_WhenExecutedWithAnOddNum_ReturnsATupleWithAFalseValue(int num)
        {
            var tupleOne = Program.ReturnATuple(num);

            Assert.IsType<Tuple<bool, string, int[]>>(tupleOne);

            Assert.False(tupleOne.Item1);
            Assert.Contains("is odd", tupleOne.Item2);
        }

        [Fact]
        public void givenTakeInATuple_WhenExecutedWithATuple_ReturnsAString()
        {
            var testTuple = Tuple.Create(10, false);
            var result = Program.TakeInATuple(testTuple);

            Assert.IsType<string>(result);
        }
    }
}