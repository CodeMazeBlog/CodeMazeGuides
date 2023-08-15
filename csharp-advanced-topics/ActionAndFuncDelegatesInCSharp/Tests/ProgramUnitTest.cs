using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    public class ProgramUnitTest
    {
        [Fact]
        public void GivenAListOfFruitNames_WhenFilterByValidFruit_ThenShouldReturnTheFirstMatch()
        {
            var list1 = new List<string>
            {
                "banana",
                "pineapple",
                "orange",
                "apple"
            };

            var fruit = Program.FirstOrDefault(list1, fruit => fruit == "orange");

            Assert.Equal("orange", fruit);
        }

        [Fact]
        public void GivenAListOfFruitNames_WhenFilterByInvalidFruit_ThenShouldReturnNull()
        {
            var list1 = new List<string>
            {
                "banana",
                "pineapple",
                "orange",
                "apple"
            };

            var fruit = Program.FirstOrDefault(list1, fruit => fruit == "pear");

            Assert.Null(fruit);
        }
    }
}