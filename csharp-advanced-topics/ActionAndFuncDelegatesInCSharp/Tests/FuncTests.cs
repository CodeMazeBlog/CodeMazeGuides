using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    public class FuncTests
    {
        [Fact]
        public void GivenPositiveNumber_ShouldReturnNotNegativeAndNotZeroErrors()
        {
            var number = 10;
            var sut = new RuleEngine();

            var result = sut.ExecuteRules(number);

            Assert.Contains(result, x => x == "Given number is not Negative");
            Assert.Contains(result, x => x == "Given number is not Zero");
        }

        [Fact]
        public void GivenNegativeNumber_ShouldReturnNotPositiveAndNotZeroErrors()
        {
            var number = -10;
            var sut = new RuleEngine();

            var result = sut.ExecuteRules(number);

            Assert.Contains(result, x => x == "Given number is not Positive");
            Assert.Contains(result, x => x == "Given number is not Zero");
        }

        [Fact]
        public void GivenZeroNumber_ShouldReturnNotPositiveAndNotNegativeErrors()
        {
            var number = 0;
            var sut = new RuleEngine();

            var result = sut.ExecuteRules(number);

            Assert.Contains(result, x => x == "Given number is not Negative");
            Assert.Contains(result, x => x == "Given number is not Positive");
        }
    }

}