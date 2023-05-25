using func.entities;

namespace DelegatesTests
{
    public class EntitiesUnitTest
    {
        [Fact]
        public void Sum_Is30_ReturnsTrue()
        {
            Calculator calculator = new Calculator(10, 20);
            string result = "SUM: 30";
            Assert.True(calculator.sum == result);
        }

        [Fact]
        public void Sum_Is30_ReturnsStringSum30()
        {
            Calculator calculator = new Calculator(10, 20);
            string result = "SUM: 30";
            Assert.Equal(result, calculator.sum);
        }

        [Fact]
        public void Withdraws_Is800_ReturnsTrue()
        {
            Account account = new Account(100, 100);
            decimal result = 800;
            Assert.True(account.savings == result);
        }

        [Fact]
        public void Withdraws_Is800_ReturnsSavingsValue800()
        {
            Account account = new Account(100, 100);
            decimal result = 800;
            Assert.Equal(result,account.savings);
        }
    }
}