using ActionAndFuncDelegates;
using Xunit;

namespace ActionAndFuncDelegatesTest
{
    public class UnitTest
    {
        [Fact]
        public void whenSumTwoNumber_thenCorrectResult()
        {
            // Arrange  
            int num1 = 2;
            int num2 = 3;
            int expectedValue = 5;

            // Act  
            int sum = Sample.Sum(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, sum);
        }

        [Fact]
        public void whenSumTwoNumberReturnString_thenCorrectResult()
        {
            // Arrange  
            int num1 = 2;
            int num2 = 3;
            string expectedValue = "5";

            // Act  
            var sum = Sample.SumToString(num1, num2);

            //Assert  
            Assert.Equal(expectedValue, sum);
        }
    }
}