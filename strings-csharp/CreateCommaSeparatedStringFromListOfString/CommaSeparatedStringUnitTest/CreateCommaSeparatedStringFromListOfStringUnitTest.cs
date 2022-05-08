using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CommaSeparatedStringUnitTest
{
    public class CreateCommaSeparatedStringFromListOfStringUnitTest
    {
        List<string> fruitList = new List<string>()
        {
            "apple",
            "orange",
            "pineapple",
            "grape",
            "coconut"
        };

        [Fact]
        public void GivenStringJoin_WhenListOfStringIsPassed_ThenReturnCommaSeparatedString()
        {
            Assert.Equal("apple,orange,pineapple,grape,coconut", string.Join(",", fruitList));
        }

        [Fact]
        public void GivenStringJoin_WhenListOfStringIsPassedAndFiltered_ThenReturnCommaSeparatedStringOfFilteredOutcome()
        {
            Assert.Equal("apple,pineapple", string.Join(",", fruitList.Where(fruit => fruit.Contains("apple"))));
        }

        [Fact]
        public void GivenStringJoin_WhenArrayOfStringIsPassedWithIndexSpecified_ThenReturnCommaSeparatedStringOfIndicatedIndexes()
        {
            Assert.Equal("pineapple,grape,coconut", string.Join(",", fruitList.ToArray(), 2, 3));
        }
    }
}