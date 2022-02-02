using System;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void GivenReturnAValueTuple_WhenExecuted_ReturnsAValueTuple()
        {
            var result = Program.ReturnAValueTuple();

            Assert.IsType<(bool, string)>(result);
        }

        [Fact]
        public void GivenReturnATuple_WhenExecuted_ReturnsAValueTuple()
        {
            var result = Program.ReturnATuple();

            Assert.IsType<Tuple<bool, string>>(result);
        }

        [Fact]
        public void GivenTakeInAValueTuple_WhenExecuted_ReturnsAString()
        {
            var valueTuple = ValueTuple.Create(4, false);
            var result = Program.TakeInAValueTuple(valueTuple);

            Assert.IsType<string>(result);
            Assert.Contains("hasAtLeastFourLegs : True and isBlue : False", result);
        }
        
        [Fact]
        public void GivenTakeInATuple_WhenExecuted_ReturnsAString()
        {
            var tuple = Tuple.Create(4, false);
            var result = Program.TakeInATuple(tuple);

            Assert.IsType<string>(result);
            Assert.Contains("hasAtLeastFourLegs : True and isBlue : False", result);
        }

        [Theory]
        [InlineData("johndoe")]
        [InlineData("codemaze")]
        public void GivenCheckStringLength_WhenExecuted_ReturnsATuple(string word)
        {
            var result = Program.CheckStringLength(word);

            Assert.IsType<(bool,string, int)>(result);
        }

        [Theory]
        [InlineData("john")]
        [InlineData("codemaze")]
        [InlineData("codemazecodemaze")]
        public void GivenCheckStringLength_WhenExecutedWithAnEvenNum_ReturnsATuple(string word)
        {
            var (isEven, messgae, _) = Program.CheckStringLength(word);

            Assert.True(isEven);
            Assert.Contains("is even", messgae);
        }

        [Theory]
        [InlineData("johndoe")]
        [InlineData("codemaze!")]
        [InlineData("codemazecodemaze!")]
        public void GivenCheckStringLength_WhenExecutedWithAnOddNum_ReturnsATuple(string word)
        {
            var (isEven, messgae, _) = Program.CheckStringLength(word);

            Assert.False(isEven);
            Assert.Contains("is odd", messgae);
        }
    }
}