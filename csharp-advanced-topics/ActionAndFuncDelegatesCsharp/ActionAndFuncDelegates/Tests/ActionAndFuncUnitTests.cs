using Xunit;
using static ActionAndFuncDelegates.ActionAndFuncUtils;

namespace Tests
{
    public class ActionAndFuncUnitTests
    {
        [Fact]
        public void WhenSumNumbers_ThenComputeCorrectSum()
        {
            SumNumbersDelegate sumDelegate = SumNumbers;
            int result = sumDelegate(1, 1);
            Assert.Equal(2, result);
        }

        [Fact]
        public void WhenSetMessage_ThenSetRightMessage()
        {
            string message = "This is the message";
            SetMessageDelegate setMessageDelegate = SetMessage;
            setMessageDelegate(message);
            Assert.Equal(message, Message);
        }

        [Fact]
        public void WhenCallbackComputeSum_ThenIsEqualToExpectation()
        {
            string actual = string.Empty;
            SumNumbersWithCallback(1, 1, (s) => actual = (s).ToString());
            SetMessage("the sum is: 2");
            Assert.Equal(actual, Message);
        }
    }
}
