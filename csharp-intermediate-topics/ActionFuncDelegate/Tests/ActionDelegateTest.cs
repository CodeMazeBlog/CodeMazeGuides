using Xunit;
using ActionFuncDelegate;

namespace ActionFuncDelegateTest {

    public class ActionDelegateTest
    {
        [Fact]
        public void GivenTwoValues_ThenCalculateSum()
        {
            int valA = 120;
            int valB = 160;
            int expectedSum = valA + valB;

            ActionDelegate.Add(valA, valB);
            Assert.Equal(expectedSum, ActionDelegate.Sum);
        }
    }
}
